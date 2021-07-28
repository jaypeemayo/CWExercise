
using CorePlusWebApi.BLL;
using CorePlusWebApi.BLL.Services;
using CorePlusWebApi.Common.Authentication;
using CorePlusWebApi.Common.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace CorePlusUnitTest
{
    [TestClass]
    public class AuthenticationServiceTest
    {
        private Mock<IConfiguration> mockConfigurationService;
        private AuthenticationService service;
        [TestInitialize]
        public void BeforeEach()
        {
            mockConfigurationService = new Mock<IConfiguration>();
            mockConfigurationService.SetupGet(x => x["Jwt:Key"]).Returns("veryVerySecretKey");
            mockConfigurationService.SetupGet(x => x["Jwt:Issuer"]).Returns("http://localhost:2550");

            service = new AuthenticationService(mockConfigurationService.Object);
        }

        [TestMethod]
        public void CreateToken_ValidUserNameAndPassword_ReturnToken()
        {              
            var token = service.CreateToken(new LoginModel() { Username= "admin", Password= "TestPass!123" });
            Assert.IsNotNull(token);
        }

        [TestMethod]
        public void CreateToken_InvalidUserNameAndPassword_ReturnNull()
        {
            var token = service.CreateToken(new LoginModel() { Username = "wrong", Password = "password" });
            Assert.IsNull(token);
        }

    }
}
