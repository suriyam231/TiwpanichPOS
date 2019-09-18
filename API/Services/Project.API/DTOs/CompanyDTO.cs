using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementService.DTOs
{
    public class CompanyDTO
    {
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public int? NumberOfProjects { get; set; }
        public string Tel { get; set; }
        public string Leader { get; set; }
        public string Team { get; set; }
    }
}
