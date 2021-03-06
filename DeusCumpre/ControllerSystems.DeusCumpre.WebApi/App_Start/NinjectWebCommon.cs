[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ControllerSystems.DeusCumpre.WebApi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ControllerSystems.DeusCumpre.WebApi.App_Start.NinjectWebCommon), "Stop")]

namespace ControllerSystems.DeusCumpre.WebApi.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using ControllerSystems.DeusCumpre.Application.Interfaces.Services;
    using ControllerSystems.DeusCumpre.Application.Services;
    using ControllerSystems.DeusCumpre.Application.Interfaces.Repositories;
    using ControllerSystems.DeusCumpre.Data.Repositories;
    using System.Web.Http;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IPublisherService>().To<PublisherService>();
            kernel.Bind<IAuthenticationService>().To<AuthenticationService>();

            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IPostRepository>().To<PostRepository>();
            kernel.Bind<ITagRepository>().To<TagRepository>();
        }
    }
}