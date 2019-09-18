using System;
using System.Collections.Generic;

namespace Database.API.Models
{
    public partial class DbBranch
    {
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
        public string Active { get; set; }
    }
}