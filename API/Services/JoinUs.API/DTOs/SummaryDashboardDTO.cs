using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterManange.API.DTOs
{
    public class SummaryDashboardDTO
    {
        //Count Dashboard HR
        public int Total_NewApplicant { get; set; }
        public int Total_WaitContact { get; set; }
        public int Total_WaitInterviewResult { get; set; }
        public int Total_WaitResult { get; set; }

        //Count Dashboard PM
        public int Total_NewApplicantPM { get; set; }
        public int Total_waitInterview { get; set; }
        public int Total_WaitaAgreement { get; set; }

    }
}
