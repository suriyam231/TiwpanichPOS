using System;
using System.Collections.Generic;

namespace RunningNo.API.Models
{
    public partial class RuRunningType
    {
        public RuRunningType()
        {
            RuRunningNo = new HashSet<RuRunningNo>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string RunningNoFormat { get; set; }
        public int RunningNoDigit { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<RuRunningNo> RuRunningNo { get; set; }
    }
}