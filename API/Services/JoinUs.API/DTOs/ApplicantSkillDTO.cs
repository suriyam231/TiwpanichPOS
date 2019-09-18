using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterManange.API.DTOs
{
    public class ApplicantSkillDTO
    {
        public int Empid { get; set; }

        // พิมพ์ดีด
        public int? TypingTh { get; set; }
        public int? TypingEn { get; set; }

        // กรุณาเรียงลำดับความสามารถด้านคอมพิวเตอร์ (เช่นภาษา/โปรแกรม/ระบบปฏิบัติการอื่นๆ)
        public string Special1 { get; set; }
        public string Special2 { get; set; }
        public string Special3 { get; set; }
        public string Special4 { get; set; }

        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
    }
}
