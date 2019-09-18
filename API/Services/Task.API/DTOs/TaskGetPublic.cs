using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.DTOs
{
    public class TaskGetPublic
    {
        public string PublicTaskCode { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string TaskName { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public string Worktype { get; set; }
        public int? Manday { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Active { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
