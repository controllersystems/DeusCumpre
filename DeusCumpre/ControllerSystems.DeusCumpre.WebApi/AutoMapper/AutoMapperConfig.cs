
using AutoMapper;
using ControllerSystems.DeusCumpre.Application.AutoMapper;
using ControllerSystems.DeusCumpre.Data.AutoMapper;
namespace ControllerSystems.DeusCumpre.WebApi.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ApplicationToViewMappingProfile>();
                x.AddProfile<ViewToApplicationMappingProfile>();

                x.AddProfile<ApplicationToModelMappingProfile>();
                x.AddProfile<ModelToApplicationMappingProfile>();

                x.AddProfile<DataToApplicationMappingProfile>();
                x.AddProfile<ApplicationToDataMappingProfile>();
            });
        }
    }
}