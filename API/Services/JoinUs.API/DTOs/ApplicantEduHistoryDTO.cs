using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterManange.API.DTOs
{
    public class ApplicantEduHistoryDTO
    {
        public int Empid { get; set; }

        // ประวัติการศึกษา
        public int? No { get; set; }
        public string Education { get; set; }
        public string SchoolName { get; set; }
        public string Faculty { get; set; }
        public string Major { get; set; }
        public DateTime GradYear { get; set; }
        public decimal? Gpa { get; set; }

        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
    }
}
