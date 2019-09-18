using Auther.API.Interfaces;
using Auther.API.Models;
using Auther.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Auther.TEST.Services
{
    [TestClass]
    public class EncryptionServiceTest
    {
        private ISRMContext Context;
        public EncryptionServiceTest()
        {
            var Option = new DbContextOptionsBuilder<SRMContext>().UseInMemoryDatabase(databaseName: "MyDb").Options;
            Context = new SRMContext(Option);
        }

        [TestMethod]
        public void Test_Encryption_succress()
        {
            EncryptionService encryption = new EncryptionService();
            string password = "test";
            string passwordsalt = "test";
            string result = encryption.HashToMD5(password+passwordsalt);
            Assert.AreEqual("05a671c66aefea124cc08b76ea6d30bb", result);
        }

        [TestMethod]
        public void Test_PasswordResalt_fail()
        {
            EncryptionService encryption = new EncryptionService();
            string password = "test";
            string passwordsalt = "testa";
            string result = encryption.HashToMD5(password + passwordsalt);
            Assert.AreNotSame("05a671c66aefea124cc08b76ea6d30bb", result);
        }

        [TestMethod]
        public void Test_Password_fail()
        {
            EncryptionService encryption = new EncryptionService();
            string password = "testa";
            string passwordsalt = "test";
            string result = encryption.HashToMD5(password + passwordsalt);
            Assert.AreNotSame("05a671c66aefea124cc08b76ea6d30bb", result);
        }

        [TestMethod]
        public void Test_Password_null()
        {
            EncryptionService encryption = new EncryptionService();
            string password = "";
            string passwordsalt = "test";
            string result = encryption.HashToMD5(password + passwordsalt);
            Assert.AreNotSame("05a671c66aefea124cc08b76ea6d30bb", result);
        }

        [TestMethod]
        public void Test_Passwordsalt_null()
        {
            EncryptionService encryption = new EncryptionService();
            string password = "test";
            string passwordsalt = "";
            string result = encryption.HashToMD5(password + passwordsalt);
            Assert.AreNotSame("05a671c66aefea124cc08b76ea6d30bb", result);
        }

        [TestMethod]
        public void Test_null()
        {
            EncryptionService encryption = new EncryptionService();
            string password = "";
            string passwordsalt = "";
            string result = encryption.HashToMD5(password + passwordsalt);
            Assert.AreNotSame("05a671c66aefea124cc08b76ea6d30bb", result);
        }
    }
}
