using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.DTOs;
using Dashboard.Interface;
using Dashboard.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboard.Controllers
{
    [Route("api/Dashboard")]
    public class TaskteamController : ControllerBase
    {
        TeamSummaryInterface TeamSummaryService;
        TaskteamInterface TaskteamService;
        IPieChart PieChartService;
        IPerson PersonService;
        IChartPerson ChartPersonService;
        IQuaterMonth QuaterMonthService;
        IQuater QuaterService;
        public TaskteamController(TaskteamInterface Taskteam, TeamSummaryInterface TeamSummary, IPieChart PieChart, IPerson Person, IChartPerson ChartPerson, 
               IQuaterMonth QuaterMonth, IQuater Quater)
        {
            TeamSummaryService = TeamSummary;
            TaskteamService = Taskteam;
            PieChartService = PieChart;
            PersonService = Person;
            ChartPersonService = ChartPerson;
            QuaterMonthService = QuaterMonth;
            QuaterService = Quater;
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult<string> Get()
        {
            return "OK";
        }


        [HttpGet]
        [Route("Taskteam")]
        [AllowAnonymous]
        public ActionResult<List<TaskteamDTO>> GetDataTaskteam()
        {
            List<TaskteamDTO> TaskteamDTO = TaskteamService.GetDataTaskteam();
            return Ok(TaskteamDTO);
        }

        [HttpGet]
        [Route("TeamSummary")]
        [AllowAnonymous]
        public ActionResult<List<TeamSummaryDTO>> GetDataTeamSummary()
        {
            List<TeamSummaryDTO> TeamSummaryDTO = TeamSummaryService.GetDataTeamSummary();
            return Ok(TeamSummaryDTO);
        }

        [HttpGet]
        [Route("PieChart")]
        [AllowAnonymous]
        public ActionResult<List<PieChartDTO>> GetPieCharts()
        {
            List<PieChartDTO> PieChartDTO = PieChartService.GetPieCharts();
            return Ok(PieChartDTO);
        }
        [HttpGet]
        [Route("Person")]
        [AllowAnonymous]
        public ActionResult<List<PersonDTO>> GetPerson()
        {
            List<PersonDTO> PersonDTO = PersonService.GetPerson();
            return Ok(PersonDTO);
        }
        [HttpGet]
        [Route("ChartPerson")]
        [AllowAnonymous]
        public ActionResult<List<ChartPersonDTO>> GetChartPerson()
        {
            List<ChartPersonDTO> ChartPersonDTO = ChartPersonService.GetChartPerson();
            return Ok(ChartPersonDTO);
        }
        [HttpGet]
        [Route("QuaterMonth")]
        [AllowAnonymous]
        public ActionResult<List<QuaterMonthDTO>> GetQuaterMonth()
        {
            List<QuaterMonthDTO> QuaterMonthDTO = QuaterMonthService.GetQuaterMonth();
            return Ok(QuaterMonthDTO);
        }
        [HttpGet]
        [Route("Quater")]
        [AllowAnonymous]
        public ActionResult<List<QuaterMonthDTO>> GetQuater()
        {
            List<QuaterDTO> QuaterDTO = QuaterService.GetQuater();
            return Ok(QuaterDTO);
        }
    }

}