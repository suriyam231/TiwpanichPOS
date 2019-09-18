using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ListOfValue.API.Interface;
using RegisterManange.API.DTOs;

namespace ListOfValue.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListOfValueController : ControllerBase
    {
        ListOfValueInterface IListOfValue;
        public ListOfValueController(ListOfValueInterface ListOfValue)
        {
            IListOfValue = ListOfValue;
        }

        [HttpGet("Get")]
        public IActionResult GetDataListOfValue()
        {
            return Ok(IListOfValue.GetDataListOfValue());
        }

        [Route("GetLastSeqNo/{groupCode}")]
        [HttpGet]
        public IActionResult GetLastSeqNo(string groupCode)
        {
            return Ok(IListOfValue.GetLastSeqNo(groupCode));
        }

        [Route("GetAllGroup")]
        [HttpGet]
        public IActionResult GetAllGroup()
        {
            return Ok(IListOfValue.GetAllGroup());
        }

        [Route("AddListOfValue")]
        [HttpPost]
        public IActionResult AddListOfValue(ListOfValueDTO value)
        {
            try
            {
                string result = IListOfValue.AddListOfValue(value);
                return Ok(result);

            }
            catch(Exception e) { return Ok(e.InnerException.Message); }
        }

        [Route("EditListOfValue")]
        [HttpPost]
        public IActionResult EditListOfValue(ListOfValueDTO value)
        {
            try
            {
                string result = IListOfValue.EditListOfValue(value);
                return Ok(result);

            } catch (Exception e) { return Ok(e.InnerException.Message); }
        }
        
        [Route("DeleteListOfValue/{groupCode}/{seqNo}")]
        [HttpDelete]
        public IActionResult DeleteListOfValue(string groupCode, int seqNo)
        {
            try
            {
                ListOfValueDTO value = new ListOfValueDTO
                {
                    GroupCode = groupCode,
                    SeqNo = seqNo
                };
                
                string result = IListOfValue.DeleteListOfValue(value);
                return Ok(result);

            } catch(Exception e) { return Ok(e.InnerException.Message); }
        }

        [Route("SearchListOfValue")]
        [HttpGet]
        public IActionResult GetDataListOfValue([FromQuery(Name = "groupCode")] string groupCode,
                                                [FromQuery(Name = "seqNo")] int? seqNo,
                                                [FromQuery(Name = "value")] string value,
                                                [FromQuery(Name = "description")] string desc,
                                                [FromQuery(Name = "active")] string active)
        {
            try
            {
                ListOfValueDTO dto = new ListOfValueDTO
                {
                    GroupCode = groupCode,
                    SeqNo = seqNo,
                    Value = value,
                    Description = desc,
                    Active = active
                };

                return Ok(IListOfValue.GetDataListOfValue(dto));

            } catch (Exception e) { throw e; }
        }


        [HttpGet("GetListofValue/{groupCode}")]
        public IActionResult GetListofValue(string groupCode)
        {
            return Ok(IListOfValue.GetListofValue(groupCode));
        }



    }
}
