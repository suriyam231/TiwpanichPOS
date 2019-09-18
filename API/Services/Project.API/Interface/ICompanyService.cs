using ProjectManagementService.DTOs;
using ProjectManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementService.Interface
{
    public interface ICompanyService
    {
        List<Company> GetCompany();
    }
}
