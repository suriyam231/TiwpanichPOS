using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class ApplicantAgreement
    {
        public int Empid { get; set; }
        public string Company { get; set; }
        public DateTime? StartDate { get; set; }
        public string Salary { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
        public string Other { get; set; }
    }
}