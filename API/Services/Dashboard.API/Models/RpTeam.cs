using System;
using System.Collections.Generic;

namespace Dashboard.API.Models
{
    public partial class RpTeam
    {
        public string TeamCode { get; set; }
        public int PointActualTeam { get; set; }
        public int PointAvailableTeam { get; set; }
        public string PersonId { get; set; }
        public string Department { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}