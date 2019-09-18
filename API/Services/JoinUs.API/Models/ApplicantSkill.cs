using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class ApplicantSkill
    {
        public int Empid { get; set; }
        public int? TypingTh { get; set; }
        public int? TypingEn { get; set; }
        public string Special1 { get; set; }
        public string Special2 { get; set; }
        public string Special3 { get; set; }
        public string Special4 { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }

        public virtual ApplicantProfile Emp { get; set; }
    }
}