using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class ApplicantWorkingHistory
    {
        public int Empid { get; set; }
        public int No { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Position { get; set; }
        public string Salary { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
        public string WorkDesc { get; set; }

        public virtual ApplicantProfile Emp { get; set; }
    }
}