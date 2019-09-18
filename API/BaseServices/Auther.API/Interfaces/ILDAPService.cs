using Auther.API.DTOs;
using Auther.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auther.API.Interfaces
{
    public interface ILDAPService
    {
        EmployeeDTO LDAP_Authenticate(string Username, string Password);
    }
}
