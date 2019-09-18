using Auther.API.DTOs;
using Auther.API.Interfaces;
using Auther.API.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Threading.Tasks;

namespace Auther.API.Services
{
    public class LDAPService : ILDAPService
    {
        public EmployeeDTO LDAP_Authenticate(string Username, string Password)
        {
            EmployeeDTO user = new EmployeeDTO();
            try
            {
                DirectoryEntry entry = new DirectoryEntry(System.LDAP_Path, Username, Password);
                DirectorySearcher searcher = new DirectorySearcher(entry);
                searcher.PageSize = 1000;
                searcher.ServerTimeLimit = new TimeSpan(0, 0, 15);
                searcher.ClientTimeout = new TimeSpan(0, 0, 15);
                searcher.Filter = string.Format("(&(objectClass=user)(SAMAccountName={0}))", Username);
                SearchResult dt = searcher.FindOne();

                user.Empcode = GetSearchResultString(dt, LDAPProperty.EmployeeCode);
                user.Username = GetSearchResultString(dt, LDAPProperty.UserName);
                user.Password = Password;
                user.FirstnameEn = GetSearchResultString(dt, LDAPProperty.FirstName);
                user.LastnameEn = GetSearchResultString(dt, LDAPProperty.LastName);
                user.Tel = GetSearchResultString(dt, LDAPProperty.MobilePhoneNo);
                user.Email = GetSearchResultString(dt, LDAPProperty.Email);

                user.Position = GetSearchResultString(dt, LDAPProperty.Position);
                //user.Company = GetSearchResultString(dt, LDAPProperty.Company);
                //user.Department = GetSearchResultString(dt, LDAPProperty.Department);

                return user;
            }
            catch (Exception)
            {
                return user;
            }
        }

         private string GetSearchResultString(SearchResult dt, string propertiesName, bool isUpper = false)
        {
            string data = string.Empty;
            if (dt != null && dt.Properties.Count > 0 && dt.Properties[propertiesName].Count > 0)
            {
                data = dt.Properties[propertiesName][0].ToString();
                if (isUpper)
                {
                    data = data.ToUpper();
                }
            }

            return data;
        }
    }
}

