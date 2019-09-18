using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementService.DTOs;
using ProjectManagementService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementService.Controllers
{
    // ต้องผ่านแม่ก่อน
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        ICompanyService CompanyService;
        public CompanyController(ICompanyService Company)
        {
            CompanyService = Company;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetDataProject()
        {
            return Ok(CompanyService.GetCompany());
        }
    }
}
