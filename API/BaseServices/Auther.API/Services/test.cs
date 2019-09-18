using Auther.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auther.API.Services
{
    public class Test
    {
        private readonly SRMContext Context;
        public Test(SRMContext _Context) {
            Context = _Context;
        }
        //public AuAuthentication InsertData() {
        //    AuAuthentication Auther = new AuAuthentication() {
        //        Active = true,
        //        SystemCode = "US00000001",
        //        Password = "1234",
        //        Username = "Test",
        //        Firstname = "Test",
        //        Lastname = "Test",
        //        CreatedBy = "Test",
        //        CreatedDate = DateTime.Now,
        //        Email = "Test@gmail.com",
        //        FailTime = 0,
        //        PasswordSalt = "Test"
                
        //    };
        //    Context.AuAuthentication.Add(Auther);
        //    Context.SaveChanges();
        //    return Auther;
        //}
    }
}
