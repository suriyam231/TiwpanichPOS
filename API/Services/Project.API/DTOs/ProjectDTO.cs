using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementService.DTOs
{
    public class ProjectDTO
    {
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string Company { get; set; }
        public bool Active { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Leader { get; set; }//ไม่มี
        public string Deseription { get; set; }
        public List<EmployeeDTO> Team { get; set; }//ไม่มี
        public int? PmManday { get; set; }
        public int? SaManday { get; set; }
        public int? SdManday { get; set; }
        public string Status { get; set; }
    }
}
