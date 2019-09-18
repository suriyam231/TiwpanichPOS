using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterManange.API.DTOs
{
    public class SummaryDashboardTableDTO
    {
        public string position { get; set; }
        public int total_applicant { get; set; }
        public int total_pass { get; set; }
        public int total_fails { get; set; }
        public string active { get; set; }
    }
}
