using System;
using System.Collections.Generic;

namespace Dashboard.API.Models
{
    public partial class RpChartMonthPerson
    {
        public string PersonCode { get; set; }
        public string MonthCode { get; set; }
        public string QuaterCode { get; set; }
        public int PointActualPerson { get; set; }
        public int PointAvailablePerson { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string PersonId { get; set; }
    }
}