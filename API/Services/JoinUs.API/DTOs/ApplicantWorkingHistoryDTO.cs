using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterManange.API.DTOs
{
    public class ApplicantWorkingHistoryDTO
    {
        public int Empid { get; set; }

        // ประวัติการทำงาน/ฝึกงาน
        public int? No { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Position { get; set; }
        public string Salary { get; set; }

        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
    }
}
