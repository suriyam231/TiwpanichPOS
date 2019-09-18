using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.DTOs
{
    public class TaskDTO
    { 
        public string Company { get; set; }
        public string TaskName { get; set; }
        public string SystemCode { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public int Manday { get; set; }
        public bool Active { get; set; }
        public string ProjectCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
