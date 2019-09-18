using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementService.DTOs
{
    public class RunningNoDTO
    {
        public string TypeCode { get; set; }
        public string TypeName { get; set; }
        public int Digit { get; set; }
        public string Format { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Code { get; set; }
    }
}
