using ProjectManagementService.DTOs;
using ProjectManagementService.Interface;
using ProjectManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementService.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly SRM_DEVContext Context;
        public CompanyService(SRM_DEVContext context)
        {
            Context = context;
        }
        public List<Company> GetCompany()
        {
          return  Context.Company.ToList();

        }
    }
}
