using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.DTOs
{
    public class TeamSummaryDTO
    {
        public string PersonID { get; set; }
        public int PointsActual { get; set; }
        public int PointsAvailable { get; set; }
        public int Quater { get; set; }
        public int Number { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
