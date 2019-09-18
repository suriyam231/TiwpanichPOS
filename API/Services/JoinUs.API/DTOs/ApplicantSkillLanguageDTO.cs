using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterManange.API.DTOs
{
    public class ApplicantSkillLanguageDTO
    {
        public int Empid { get; set; }

        // ความสามารถทางภาษา
        public int? No { get; set; }
        public string Language { get; set; }
        public string LanguageSpeak { get; set; }
        public string LanguageRead { get; set; }
        public string LanguageWrite { get; set; }

        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
    }
}
