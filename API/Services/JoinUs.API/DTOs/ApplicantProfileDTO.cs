using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterManange.API.DTOs
{
    public class ApplicantProfileDTO
    {
        public int Empid { get; set; }

        // รูปโปรไฟล์
        public string ImgPath { get; set; }

        // ลักษณะงานที่ต้องการ
        public string Position { get; set; }
        public string Salary { get; set; }

        // ข้อมูลส่วนตัว
        public string TitelnameTh { get; set; }
        public string FirstnameTh { get; set; }
        public string LastnameTh { get; set; }
        public string TitelnameEn { get; set; }
        public string FirstnameEn { get; set; }
        public string LastnameEn { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
        public string IdCard { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }

        // ข้อมูลการติดต่อ
        public string Tel { get; set; }
        public string Email { get; set; }
        public string LineID { get; set; }

        // ข้อมูลที่อยู่ปัจจุบัน
        public string Address { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public int? PostalCode { get; set; }
        public string Stay { get; set; }

        public string StatusApplicant { get; set; }

        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
        public string TypeEmployee { get; set; }

    }
}
