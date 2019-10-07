using System;
using System.Collections.Generic;

namespace Database.API.Models
{
    public partial class Subdistricts
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string NameInThai { get; set; }
        public string NameInEnglish { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int DistrictId { get; set; }
        public int? ZipCode { get; set; }

        public virtual Districts District { get; set; }
    }
}