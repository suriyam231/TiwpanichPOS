using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auther.API
{
    public struct System
    {
        public const string ConnectString = @"Data Source=172.16.0.249;Initial Catalog=SRM_DEV;Persist Security Info=True;User ID=sa;Password=p@ssw0rd";
        public const string LDAP_Path = "LDAP://softsquaregroup.com";
    }
    public struct LDAPProperty
    {
        //People
        public const string EmployeeCode = "initials";
        public const string UserName = "SAMAccountName";
        public const string FirstName = "givenName";
        public const string LastName = "sn";
        public const string MobilePhoneNo = "mobile";
        public const string Email = "mail";
        public const string Position = "title";
        public const string Company = "company";
        public const string Department = "department";
    }

    public struct RunningNo
    {
        public const string UserSystemCode = "01";
        public const string paramUser1 = "US";
    }
    public struct MD5Property
    {
        public const string StandardMD5Key = "IAMSUPERMAN@123";
        public const string PasswordWordResult = "IRONMAN@123";
        public const string StringMD5 = "D5";
    }
    public struct Authers
    {
        public const string Issuer = "SRM";
        public const string Audience = "SRM";
        public const string SigningKey = "Y2F0Y2hlciUyMHdvbmclMjBsb3ZlJTIwLm5ldA==";

    }
}
