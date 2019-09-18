using ListApplicant.API.Interface;
using Microsoft.AspNetCore.Mvc;
using RegisterManange.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListApplicant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListApplicantController : ControllerBase
    {
        ListApplicantsInterface IListApplicant;
        public ListApplicantController(ListApplicantsInterface ListApplicant)
        {
            IListApplicant = ListApplicant;
        }


        [Route("ListApplicant/{position}")]
        [HttpGet("Get")]
        public IActionResult GetProfileByPM(string position)
        {
            return Ok(IListApplicant.GetDataProfileByPM(position));
        }          

        [Route("ApplicantByPM")]
        [HttpGet]
        public IActionResult GetProfileByPM([FromQuery(Name = "name")] string name, [FromQuery(Name = "date")] string date,[FromQuery(Name = "type")] string type,[FromQuery(Name = "department")] string department)
        {
            return Ok(IListApplicant.GetDataProfileByPM(name, date,type, department));
        }

        [Route("SaveinterviewDate/{team}")]
        [HttpPost]
        public async Task<ActionResult<string>> Post(ApplicantAppointmentDateDTO data, string team)
        {
            try
            {
                string resultSave = await IListApplicant.SaveinterviewDate(data, team);
                return Ok();
            }
            catch (Exception ex) { return ex.Message; }
        }

        [Route("HistoryListApplicant/{role}/{department}/{team}")]
        [HttpGet("Get")]
        public IActionResult GetHistoryListApplicant(string role,string department, string team)
        {
            return Ok(IListApplicant.GetHistoryListApplicant(role, department, team));
        }

        [Route("searchHistoryList/{role}/{department}/{team}")]
        [HttpGet]
        public IActionResult searchHistoryList(string role, string department, string team,[FromQuery(Name = "name")] string name, [FromQuery(Name = "status")] string status, [FromQuery(Name = "type")] string type,[FromQuery(Name = "searchDate")] string date,[FromQuery(Name = "searchPosition")] string searchPosition)
        {
            return Ok(IListApplicant.searchHistoryList(role, department, team, name, status, type,date,searchPosition));
        }

    }


}
