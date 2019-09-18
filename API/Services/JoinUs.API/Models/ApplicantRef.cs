using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class ApplicantRef
    {
        public int Empid { get; set; }
        public int No { get; set; }
        public string RefName { get; set; }
        public string RefPosition { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
        public string RefTel { get; set; }

        public virtual ApplicantProfile Emp { get; set; }
    }
}