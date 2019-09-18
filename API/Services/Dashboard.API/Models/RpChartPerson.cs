using System;
using System.Collections.Generic;

namespace Dashboard.API.Models
{
    public partial class RpChartPerson
    {
        public string PersonId { get; set; }
        public string PersonCode { get; set; }
        public int PointActualPerson { get; set; }
        public int PointAvailablePerson { get; set; }
        public string QuaterCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}