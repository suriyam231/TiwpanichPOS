using System;
using System.Collections.Generic;

namespace ProjectManagementService.Models
{
    public partial class Company
    {
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public int? NumberOfProjects { get; set; }
        public string Tel { get; set; }
        public string Leader { get; set; }
        public string Team { get; set; }
    }
}