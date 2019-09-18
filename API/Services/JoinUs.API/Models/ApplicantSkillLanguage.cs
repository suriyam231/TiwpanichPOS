using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class ApplicantSkillLanguage
    {
        public int Empid { get; set; }
        public int No { get; set; }
        public string Language { get; set; }
        public string LanguageSpeak { get; set; }
        public string LanguageRead { get; set; }
        public string LanguageWrite { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }

        public virtual ApplicantProfile Emp { get; set; }
    }
}