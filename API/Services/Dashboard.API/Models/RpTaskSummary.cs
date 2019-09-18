using System;
using System.Collections.Generic;

namespace Dashboard.API.Models
{
    public partial class RpTaskSummary
    {
        public string TaskPersonCode { get; set; }
        public string PersonCode { get; set; }
        public string Status { get; set; }
        public string TeamCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string QuaterCode { get; set; }
        public string PersonId { get; set; }
    }
}