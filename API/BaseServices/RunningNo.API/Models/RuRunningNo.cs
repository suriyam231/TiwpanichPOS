using System;
using System.Collections.Generic;

namespace RunningNo.API.Models
{
    public partial class RuRunningNo
    {
        public int Id { get; set; }
        public string RunningTypeCode { get; set; }
        public string Parameter1 { get; set; }
        public string Parameter2 { get; set; }
        public string Parameter3 { get; set; }
        public string Parameter4 { get; set; }
        public string Parameter5 { get; set; }
        public string Parameter6 { get; set; }
        public string Parameter7 { get; set; }
        public string Parameter8 { get; set; }
        public string Parameter9 { get; set; }
        public string Parameter10 { get; set; }
        public int? RunningNo { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual RuRunningType RunningTypeCodeNavigation { get; set; }
    }
}