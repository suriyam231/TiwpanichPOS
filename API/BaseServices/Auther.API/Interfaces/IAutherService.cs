using Auther.API.DTOs;
using Auther.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auther.API.Interfaces
{
    public interface IAutherService
    {
        Task<TokenDTO> LoginAsync(string Username, string Password);
        TokenDTO Login(string Username, string Password);
        Task<string> CreateNewUserAsync(EmployeeDTO ADUser);
        string GenerateToken(string SystemCode);
        List<Employee> GetAuther();
    }
}
