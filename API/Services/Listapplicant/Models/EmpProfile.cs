using System;
using System.Collections.Generic;

namespace Listapplicant.Models
{
    public partial class EmpProfile
    {
        public string EmpId { get; set; }
        public string TitleName { get; set; }
        public string FirstNameTh { get; set; }
        public string LastNameTh { get; set; }
        public string FirstNameEn { get; set; }
        public string LastNameEn { get; set; }
        public string Position { get; set; }
        public DateTime? StartWorking { get; set; }
        public int? Salary { get; set; }
        public DateTime? BirthDay { get; set; }
        public string HomeTown { get; set; }
        public string NickName { get; set; }
        public int? Age { get; set; }
        public string IdcardNumber { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        public int? Tall { get; set; }
        public int? Weigh { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public string PostalCode { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Etc { get; set; }
        public string ImgPath { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
    }
}