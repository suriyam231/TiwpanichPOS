using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agreement.API.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterManange.API.Models;

namespace Agreement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgreementController : ControllerBase
    {
        AgreementInterface IAgreement;
        public AgreementController(AgreementInterface Agreement)
        {
            IAgreement = Agreement;
        }

        [Route("GetDatatoAgreementByEmpId/{empId}")]
        [HttpGet("Get")]
        public IActionResult GetDatatoAgreementByEmpId(int empId)
        {
            return Ok(IAgreement.GetDatatoAgreementByEmpId(empId));
        }

        [Route("GetDatatoAgreement/{team}")]
        [HttpGet("Get")]
        public IActionResult GetDatatoAgreement(string team)
        {
            return Ok(IAgreement.GetDatatoAgreement(team));
        }

        [Route("AddAgreement")]
        [HttpPost]
        public ActionResult<string> AddRegisterPosition(ApplicantAgreement data)
        {
            try
            {
                string result = IAgreement.AddDatatoAgreement(data);
                return Ok();
            }
            catch (Exception e) { return e.InnerException.Message; }
        }

        [Route("GetAgreementBySearch")]
        [HttpGet]
        public IActionResult GetProfileByPM([FromQuery(Name = "name")] string name, [FromQuery(Name = "date")] string date, [FromQuery(Name = "team")] string team,[FromQuery(Name = "type")] string type)
        {
            return Ok(IAgreement.GetDataBySearch(name, date, team,type));
        }
    }
}