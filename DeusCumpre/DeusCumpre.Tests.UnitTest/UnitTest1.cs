using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControllerSystems.DeusCumpre.Domain.Entities;
using ControllerSystems.DeusCumpre.Application.Services;
using ControllerSystems.DeusCumpre.Data.Repositories;

namespace DeusCumpre.Tests.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LogIn()
        {
            User user = new User()
            {
                Login = "rodrigo.cruz",
                Password = "1234"
            };
            bool result = user.LogIn(new Authentication(new UserRepository()));

            Assert.AreEqual(false, result);
        }
    }
}