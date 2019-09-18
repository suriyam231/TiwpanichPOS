using System;
using System.Collections.Generic;

namespace Dashboard.API.Models
{
    public partial class RpChartQuater
    {
        public string QuaterCode { get; set; }
        public int PointActualTeam { get; set; }
        public int PointAvailableTeam { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string TeamCode { get; set; }
        public string QuaterName { get; set; }
    }
}