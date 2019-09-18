using DashboardHr.API.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardHr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardHrController : ControllerBase
    {
        DashboardHrInterface IDashboardHr;
        public DashboardHrController(DashboardHrInterface DashboardHr)
        {
            IDashboardHr = DashboardHr;
        }

        //[Route("Graph")]
        [HttpGet("Get")]
        public IActionResult GetDataGraph()
        {
            return Ok(IDashboardHr.GetDataGraph());
        }

        [HttpGet("GetSummaryDashboard")]
        public IActionResult GetSummaryDashboard()
        {
            return Ok(IDashboardHr.GetSummaryDashboard());
        }

        [HttpGet("GetSummaryDashboardTable")]
        public IActionResult GetSummaryDashboardTable()
        {
            return Ok(IDashboardHr.GetSummaryDashboardTable());
        }

        [HttpGet("GetSummaryDashboardPM/{team}/{department}")]
        public IActionResult GetSummaryDashboardPM(string team, string department)
        {
            return Ok(IDashboardHr.GetSummaryDashboardPM(team, department));
        }
        
    }
}
