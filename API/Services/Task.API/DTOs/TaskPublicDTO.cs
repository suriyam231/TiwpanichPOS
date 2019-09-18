using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.DTOs
{
    public class TaskPublicDTO
    {
        public string TaskCode { get; set; }
        public string ProjectCode { get; set; }
        public List<string> TaskName { get; set; }
        public string Status { get; set; }
    }
}
