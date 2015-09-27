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
    }
}