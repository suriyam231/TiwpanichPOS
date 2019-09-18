using ListApplicant.API.DTOs;
using ListInterviewerResult.API.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegisterManange.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListInterviewerResult.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListInterviewerResultController : ControllerBase
    {
        IListInterviewerResultInterface IListInterviewerResult;
        public ListInterviewerResultController(IListInterviewerResultInterface listInterviewerResult)
        {
            IListInterviewerResult = listInterviewerResult;
        }

        [Route("ListInterviewerResult")]
        [HttpGet("Get")]
        public IActionResult GetAssessment()
        {
            return Ok(IListInterviewerResult.GetAssessment());
        }

        [HttpGet("AssessmentResult/{id}")]
        [AllowAnonymous]
        public IActionResult GetProfileByID(int id)
        {
            return Ok(IListInterviewerResult.GetDataAssessmentByID(id));
        }

        [Route("SearchListInterviewerResult")]
        [HttpGet]
        public IActionResult GetDataSearchListInteresting([FromQuery(Name = "name")] string name, [FromQuery(Name = "position")] string position,[FromQuery(Name = "type")] string type)
        {
            return Ok(IListInterviewerResult.GetDataSearchListInterviewerResult(name,position,type));
        }
    }
}
