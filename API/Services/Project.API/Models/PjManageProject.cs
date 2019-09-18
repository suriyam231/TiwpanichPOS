using System;
using System.Collections.Generic;

namespace ProjectManagementService.Models
{
    public partial class PjManageProject
    {
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string CompanyCode { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Deseription { get; set; }
        public int? PmManday { get; set; }
        public int? SaManday { get; set; }
        public int? SdManday { get; set; }
        public string Status { get; set; }
    }
}