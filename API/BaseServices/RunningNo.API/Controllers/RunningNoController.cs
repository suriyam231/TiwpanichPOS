using Microsoft.AspNetCore.Mvc;
using RunningNo.API.DTOs;
using RunningNo.API.Interfaces;
using RunningNo.API.Models;
using RunningNo.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace RunningNo.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RunningNoController : ControllerBase
    {
        IRunningNoService RunningNoService;
        
        public RunningNoController(IRunningNoService _runningNoService)
        {
            RunningNoService = _runningNoService;
        }
        [HttpGet("SystemCode")]
        public ActionResult<ReturnMessageDTO> GetSystemCode(string runningCode,params string[] parameter)
        {
            try
            {
                parameter = parameter.Select(x => x.ToUpper()).ToArray();
                ReturnMessageDTO returnMessageDTO = RunningNoService.GenerateRunningNo(runningCode, parameter);
                return returnMessageDTO;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }
    }  
}
