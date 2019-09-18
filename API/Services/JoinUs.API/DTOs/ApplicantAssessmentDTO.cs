using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterManange.API.DTOs
{
    public class ApplicantAssessmentDTO
    {
        public int Empid { get; set; }
        public string FirstnameTh { get; set; }
        public string LastnameTh { get; set; }
        public string Position { get; set; }
        public string Per_01 { get; set; }
        public string Per_02 { get; set; }
        public string Per_03 { get; set; }
        public string Per_04 { get; set; }
        public string Edu_01 { get; set; }
        public string Edu_02 { get; set; }
        public string Edu_03 { get; set; }
        public string Edu_04 { get; set; }
        public string Oth_01 { get; set; }
        public string Oth_02 { get; set; }
        public string Recomment { get; set; }
        public string Summ_Ass { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public object ApplicantAssetment { get; internal set; }
        public object ApplicantProfile { get; internal set; }
    }
}
