using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class ApplicantEduHistory
    {
        public int Empid { get; set; }
        public int No { get; set; }
        public string Education { get; set; }
        public string SchoolName { get; set; }
        public string Faculty { get; set; }
        public string Major { get; set; }
        public string GradYear { get; set; }
        public decimal? Gpa { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }

        public virtual ApplicantProfile Emp { get; set; }
    }
}