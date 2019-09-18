using RegisterManange.API.DTOs;
using RegisterManange.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardHr.API.Interface
{
    public interface DashboardHrInterface
    {
        List<GraphDTO> GetDataGraph();//get
        SummaryDashboardDTO GetSummaryDashboard();
        SummaryDashboardDTO GetSummaryDashboardPM(string team, string Deartment);
        List<SummaryDashboardTableDTO> GetSummaryDashboardTable();
    }
}
