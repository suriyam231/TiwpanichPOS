using System;
using System.Collections.Generic;

namespace ProjectManagementService.Models
{
    public partial class PjEmployee
    {
        public string SystemCode { get; set; }
        public string ProjectCode { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Leader { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}