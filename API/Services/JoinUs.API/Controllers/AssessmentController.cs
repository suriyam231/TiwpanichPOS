using Microsoft.AspNetCore.Mvc;
using AssessmentByPM.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using RegisterManange.API.DTOs;

namespace AssessmentByPM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentController : ControllerBase
    {
        AssessmentInterface IAssessmen;
        public AssessmentController(AssessmentInterface Assessment)
        {
            IAssessmen = Assessment;
        }

        [Route("AssessmentByPM/{team}")]
        [HttpGet("Get")]
        public IActionResult GetDataAssessmenByPM(string team)
        {
            return Ok(IAssessmen.GetDataAssessmenByPM(team));
        }

        [HttpGet("AssessmentPmById/{id}")]
        [AllowAnonymous]
        public IActionResult GetProfileByID(int id)
        {
            return Ok(IAssessmen.GetDataAssessmentPmByID(id));
        }

        [Route("SearchByPM")]
        [HttpGet]
        public IActionResult GetDataAssessmentByPM([FromQuery(Name = "name")] string name, [FromQuery(Name = "date")] string date, [FromQuery(Name = "team")] string team,[FromQuery(Name = "type")] string type)
        {
            return Ok(IAssessmen.GetDataAssessmentByPM(name, date, team,type));
        }

        [Route("SaveAssessmentOnline/{status}/{name}")]
        [HttpPost]
        public async Task<ActionResult<string>> Post(ApplicantAssessmentDTO data, string status,string name) 
        {
            try
            {
                string resultSave = await IAssessmen.SaveAssessmentOnline(data,name);
                string resultUpdate = IAssessmen.UpdateStatus(data.Empid, status,name);
                return Ok();
            }
            catch (Exception ex) { return ex.Message; }
        } 
    }
}
