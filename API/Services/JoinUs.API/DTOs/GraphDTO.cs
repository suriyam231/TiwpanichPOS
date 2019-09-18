using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterManange.API.DTOs
{
    public class GraphDTO
    {
        public DateTime? CrDate { get; set; }
        public string Month { get; set; }
        public int TotalApplicant { get; set; }
        public int TotalPass { get; set; }
        public int TotalNotPass { get; set; }
    }
}
