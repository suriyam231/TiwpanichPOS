using ResoucreManager.API.DTOs;
using ResoucreManager.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResoucreManager.API.Interface
{
    public interface EmployeeProfileInterface
    {
        EmployeeDTO getEmployeeProfile(string empCode);
        Task<string> saveEmployeeProfile(EmployeeDTO data);
    }
}
