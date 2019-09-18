using System;
using System.Collections.Generic;

namespace Database.API.Models
{
    public partial class DbCompany
    {
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
    }
}