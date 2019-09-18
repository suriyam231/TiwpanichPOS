using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementService.DTOs
{
    public class EmployeeDTO
    {
        public string SystemCode { get; set; }
        public string ProjectCode { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Leader { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
    }
}
