using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.API.DTOs
{
    public class EditBranchDTO
    {
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string CrBy { get; set; }
        public string UpdBy { get; set; }
        public string Active { get; set; }
        public string OldBranchCode { get; set; }
        public string OldBranchName { get; set; }

    }
}
