using Auther.API.Models;
using Auther.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Auther.TEST.Services
{
    [TestClass]
    public class LDAPServiceTest
    {
        private readonly ISRMContext Context;
        public LDAPServiceTest()
        {
            var Option = new DbContextOptionsBuilder<SRMContext>().UseInMemoryDatabase(databaseName: "MyDb").Options;
            Context = new SRMContext(Option);
        }

        [TestMethod]
        public void TestLDAP_success()
        {
            LDAPService LDAPServices = new LDAPService();
            Authentication result = LDAPServices.LDAP_Authenticate("wongsathorn_p", "GuGuitar001");
            Assert.AreEqual("wongsathorn_p", result.Username);
        }
        [TestMethod]
        public void TestLDAP_fail()
        {
            LDAPService LDAPServices = new LDAPService();
            Authentication result = LDAPServices.LDAP_Authenticate("wongsathorn_p", "GuGuitar002");
            Assert.AreEqual(null, result.Username);
        }

    }
}
