using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControllerSystems.DeusCumpre.Domain.Entities;
using ControllerSystems.DeusCumpre.Application.Services;
using ControllerSystems.DeusCumpre.Data.Repositories;
using ControllerSystems.DeusCumpre.Application.DataTransferObjects;
using ControllerSystems.DeusCumpre.Data.AutoMapper;
using ControllerSystems.DeusCumpre.Application.AutoMapper;
using System.Collections.Generic;

namespace DeusCumpre.Tests.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SetVariables()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
        }

        [TestMethod]
        public void PasswordIsNotValid()
        {
            try
            {
                User user = new User()
                {
                    Login = "login"
                };
                var result = user.IsValid;

                Assert.AreEqual(false, result);
            }
            catch (ArgumentNullException argEx)
            {
                Assert.AreEqual("Password", argEx.ParamName);
            }
        }

        [TestMethod]
        public void LoginIsNotValid()
        {
            try
            {
                User user = new User()
                {
                    Password = "password"
                };

                var result = user.IsValid;

                Assert.AreEqual(false, result);
            }
            catch (ArgumentNullException argEx)
            {
                Assert.AreEqual("Login", argEx.ParamName);
            }
        }

        [TestMethod]
        public void LogIn()
        {
            AuthenticationService authenticationService = new AuthenticationService(new UserRepository());

            var result = authenticationService.LogIn("rodrigo.cruz", "1234");

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void CreateUser()
        {
            AutoMapperDataConfig.RegisterMappings();
            AuthenticationService authenticationService = new AuthenticationService(new UserRepository());

            var userDto = new UserDto()
            {
                IsAdmin = false,
                Login = "admin",
                Password = "123"
            };
            var result = authenticationService.Create(userDto);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CreatePost()
        {
            AutoMapperDataConfig.RegisterMappings();
            PublisherService publisherService = new PublisherService(new PostRepository(), new TagRepository());

            var postDto = new PostDto()
            {
                Body = "Body",
                Title = "Title",
                User = new UserDto()
                {
                    Login = "admin"
                },
                Tags = new List<string>
                {
                    "Deus", "Bíblia", "Deus vivo"
                }
            };

            publisherService.Publish(postDto);
        }

        [TestMethod]
        public void UpdatePost()
        {
            AutoMapperDataConfig.RegisterMappings();
            PublisherService publisherService = new PublisherService(new PostRepository(), new TagRepository());

            var postDto = new PostDto()
            {
                Id = 1,
                Body = "Body 1",
                Title = "Title 1",
                User = new UserDto()
                {
                    Login = "rodrigo.cruz2"
                }
            };

            publisherService.Edit(postDto);

            var postUpdated = publisherService.GetById(1);

            Assert.IsNotNull(postUpdated);

            Assert.AreEqual(postDto.Body, postUpdated.Body);

            Assert.AreEqual(postDto.Title, postUpdated.Title);
        }

        [TestMethod]
        public void DeletePost()
        {
            AutoMapperDataConfig.RegisterMappings();
            PublisherService publisherService = new PublisherService(new PostRepository(), new TagRepository());

            int maxId = publisherService.GetAllPosts().Max(x => x.Id);

            var postDto = new PostDto()
            {
                Id = maxId
            };

            publisherService.Delete(postDto);

            var postDeleted = publisherService.GetById(maxId);

            Assert.IsNull(postDeleted);
        }
    }
}