using Microsoft.EntityFrameworkCore;
using Auther.TEST.CASE;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Auther.API.Interfaces;
using Auther.API.Models;
using Auther.API.DTOs;
using Auther.API.Services;

namespace Auther.TEST.Services
{
    [TestClass]
    public class AutherServiceTest
    {
        private Mock<ILDAPService> LDAPService;
        private Mock<IRunningNoService> RunningNoService;
        private Mock<IEncryptionService> EncryptionService;
        private ISRMContext Context;
        public AutherServiceTest()
        {
            var Option = new DbContextOptionsBuilder<SRMContext>().UseInMemoryDatabase(databaseName: "MyDb").Options;
            Context = new SRMContext(Option);
            InterfaceAuther();
            MockDataToDB();
        }

        public void InterfaceAuther() {
            LDAPService = new Mock<ILDAPService>(MockBehavior.Strict);
            RunningNoService = new Mock<IRunningNoService>(MockBehavior.Strict);
            EncryptionService = new Mock<IEncryptionService>(MockBehavior.Strict);
            LDAPService.Setup(l => l.LDAP_Authenticate(It.IsAny<string>(), It.IsAny<string>())).Returns(new Authentication());
            RunningNoService.Setup(r => r.GenerateRunningNo()).ReturnsAsync(new RunningNoDTO());
            EncryptionService.Setup(e => e.HashToMD5(It.IsAny<string>())).Returns(It.IsAny<string>());
        }
        public void MockDataToDB()
        {
            foreach (var entity in Context.Authentication)
                Context.Authentication.Remove(entity);
            Context.SaveChanges();
            Context.Authentication.Add(new Authentication()
            {
                Username = "Test",
                Password = "05a671c66aefea124cc08b76ea6d30bb",//password = test
                PasswordSalt = "test",
                Firstname = "test",
                Lastname = "test",
                Email = "test@mail.com",
                Active = true,
                FailTime = 0,
                PasswordExpiryDate = DateTime.Now.AddYears(1),
                SystemCode = "US00000001",
                CreatedBy = "System",
                CreatedDate = DateTime.Parse("5/1/2008 8:30:52 AM", System.Globalization.CultureInfo.InvariantCulture)
            });
            Context.SaveChanges();
        }

        [TestMethod]
        public void TestSuccess()
        {
            EncryptionService.Setup(e => e.HashToMD5(It.IsAny<string>())).Returns("05a671c66aefea124cc08b76ea6d30bb");
            AutherService AuthersService = new AutherService(Context, LDAPService.Object, RunningNoService.Object, EncryptionService.Object); 
            TokenDTO result = AuthersService.Login("Test", "test");
            Assert.AreEqual("Login Success", result.Message);
        }

        [TestMethod]
        public void Testnull()
        {
            AutherService AuthersService = new AutherService(Context, LDAPService.Object, RunningNoService.Object, EncryptionService.Object);
            TokenDTO result = AuthersService.Login("", "");
            Assert.AreEqual("Data is null", result.Message);
        }

        [TestMethod]
        public void TestPasswordfail()
        {
            EncryptionService.Setup(e => e.HashToMD5(It.IsAny<string>())).Returns("sdfsdf");
            AutherService AuthersService = new AutherService(Context, LDAPService.Object, RunningNoService.Object, EncryptionService.Object); 
            TokenDTO result = AuthersService.Login("Test", "sdfsdf");
            Assert.AreEqual("The username or password is incorrect. Please Try again", result.Message);
        }

        [TestMethod]
        public void TestUsernamefail()
        {
            EncryptionService.Setup(e => e.HashToMD5(It.IsAny<string>())).Returns("test");
            AutherService AuthersService = new AutherService(Context, LDAPService.Object, RunningNoService.Object, EncryptionService.Object); 
            TokenDTO result = AuthersService.Login("asd", "test");
            Assert.AreEqual("Data is null", result.Message);
        }

        [TestMethod]
        public void TestPasswordnull()
        {
            AutherService AuthersService = new AutherService(Context, LDAPService.Object, RunningNoService.Object, EncryptionService.Object); 
            TokenDTO ressult = AuthersService.Login("Test", "");
            Assert.AreEqual("The username or password is incorrect. Please Try again", ressult.Message);
        }

        [TestMethod]
        public void TestUsernamenull()
        {
            EncryptionService.Setup(e => e.HashToMD5(It.IsAny<string>())).Returns("test");
            AutherService AuthersService = new AutherService(Context, LDAPService.Object, RunningNoService.Object, EncryptionService.Object);
            TokenDTO result = AuthersService.Login("", "test");
            Assert.AreEqual("Data is null", result.Message);
        }

        [TestMethod]
        public void TestCreatedUser()
        {
            RunningNoDTO Running = new RunningNoDTO();
            Running.Code = "US00000002";
            RunningNoService.Setup(r => r.GenerateRunningNo()).ReturnsAsync(Running);
            EncryptionService.Setup(e => e.HashToMD5(It.IsAny<string>())).Returns("05a671c66aefea124cc08b76ea6d30bb");
           EncryptionService.Setup(e => e.GeneratePasswordSalt()).Returns("sdfsef23e32");
            Authentication Authers = new Authentication()
            { 
                Username = "Test",
                Firstname = "test",
                Lastname = "test",
                Email = "test@mail.com",
            };
            AutherService AuthersService = new AutherService(Context, LDAPService.Object, RunningNoService.Object, EncryptionService.Object); 
            Assert.AreEqual(Running.Code, AuthersService.CreateNewUserAsync(Authers).Result);
            
        }

        //[TestMethod]
        //public void TestGenerateToken() // ยังไม่เสร็จ 
        //{
        //    AutherService AuthersService = new AutherService(Context, LDAPService.Object, RunningNoService.Object, EncryptionService.Object);
        //    var token = new JwtSecurityToken("Token");
        //    Assert.AreEqual(token, AuthersService.GenerateToken("US00000001"));
        //}
    }
}
