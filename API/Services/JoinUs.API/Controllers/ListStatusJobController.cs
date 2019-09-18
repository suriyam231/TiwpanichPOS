using ListStatusJob.API.Interface;
using Microsoft.AspNetCore.Mvc;
using RegisterManange.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListStatusJob.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListStatusJobController : ControllerBase
    {
        ListStatusJobInterface IListStatusJob;
        public ListStatusJobController(ListStatusJobInterface ListStatusJob)
        {
            IListStatusJob = ListStatusJob;
        }

        [HttpGet("Get")]
        public IActionResult GetDataPosition()

        {
            return Ok(IListStatusJob.GetDataPosition());
        }

        [Route("GetPositionMaster")]
        [HttpGet]
        public IActionResult GetPositionMaster()
        {
            return Ok(IListStatusJob.GetPositionMaster());
        }

        [Route("AddRegisterPosition")]
        [HttpPost]
        public ActionResult<string> AddRegisterPosition([FromBody] PositionDTO position)
        {
            try
            {
                string result = IListStatusJob.AddRegisterPosition(position);
                return Ok(result);
            }
            catch (Exception e) { return e.InnerException.Message; }
        }

        [Route("EditRegisterPosition")]
        [HttpPost]
        public ActionResult<string> EditRegisterPosition([FromBody] PositionDTO position)
        {
            try
            {
                string result = IListStatusJob.EditRegisterPosition(position);
                return Ok(result);
            }
            catch (Exception e) { return e.Message; }
        }

        [Route("DeleteRegisterPosition/")]
        [HttpDelete]
        public ActionResult<string> DeleteRegisterPosition([FromQuery] int id)
        {
            try
            { 
                string result = IListStatusJob.DeleteRegisterPosition(id);
                return result;
            }
            catch (Exception e) { return e.Message; }
        }

    }
}
