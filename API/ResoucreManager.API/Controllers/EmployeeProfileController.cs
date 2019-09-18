using Microsoft.AspNetCore.Mvc;
using ResoucreManager.API.DTOs;
using ResoucreManager.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResoucreManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeProfileController : ControllerBase
    {

        EmployeeProfileInterface IEmployeeProfile;
        public EmployeeProfileController(EmployeeProfileInterface employeeProfile)
        {
            IEmployeeProfile = employeeProfile;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet("GetEmployeeProfile/{empCode}")]
        public EmployeeDTO GetEmployeeProfile(string empCode)
        {
            EmployeeDTO employeeProfile = IEmployeeProfile.getEmployeeProfile(empCode);

            return employeeProfile;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(EmployeeDTO data)
        {
            return Ok(await IEmployeeProfile.saveEmployeeProfile(data));
        }
    }
}