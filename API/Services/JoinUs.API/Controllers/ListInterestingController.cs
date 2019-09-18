using ListInteresting.API.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegisterManange.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListInteresting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListInterestingController : ControllerBase
    {
        ListInterestingInterface IListInteresting;
        public ListInterestingController(ListInterestingInterface listInteresting)
        {
            IListInteresting = listInteresting;
        }


        [HttpGet("Get")]
        public IActionResult GetProfileInteresting()
        {
            return Ok(IListInteresting.getDataIntertings());
        }

        [HttpGet("Getdata")]
        public IActionResult GetProfileInterestings()
        {
            return Ok(IListInteresting.getDataIntertingsss());
        }


        [Route("UpdateStatusInteresting/{status}")]
        [HttpPut]
        public IActionResult UpdateStatusInteresting([FromBody] int[] id, string status)
        {
            string result = IListInteresting.UpdateStatusInteresting(id, status);
            return Ok();
        }

        [Route("SearchListInteresting")]
        [HttpGet]
        public IActionResult GetDataSearchListInteresting([FromQuery(Name = "name")] string name, [FromQuery(Name = "date")] string date, [FromQuery(Name = "status")] string status,[FromQuery(Name = "type")] string type)
        {
            return Ok(IListInteresting.GetDataListinteresting(name, date, status,type));
        }

        [Route("UpdateAppointmentDate")]
        [HttpPut]
        public IActionResult UpdateAppointmentDate([FromBody] List<UpdateApplicantInterestingsDTO> updatedata)
        {
            string result = IListInteresting.UpdateAppointmentDate(updatedata);
            return Ok();
        }
        




    }
}
