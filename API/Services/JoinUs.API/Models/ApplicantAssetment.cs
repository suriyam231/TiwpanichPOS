using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class ApplicantAssetment
    {
        public int Empid { get; set; }
        public string Per01 { get; set; }
        public string Per02 { get; set; }
        public string Per03 { get; set; }
        public string Per04 { get; set; }
        public string Edu01 { get; set; }
        public string Edu02 { get; set; }
        public string Edu03 { get; set; }
        public string Edu04 { get; set; }
        public string Oth01 { get; set; }
        public string Oth02 { get; set; }
        public string Recomment { get; set; }
        public string SummAss { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
    }
}