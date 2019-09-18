using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterManange.API.DTOs
{
    public class ApplicantRefDTO
    {
        public int Empid { get; set; }

        // รายชื่อบุคคลอ้างอิง ซึ่งมิใช่ญาติหรือผู้ว่าจ้าง ซึ่งบริษัทฯ สามารถสอบประวัติท่านได้
        public int? No { get; set; }
        public string RefName { get; set; }
        public string RefPosition { get; set; }
        public string RefTel { get; set; }

        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
    }
}
