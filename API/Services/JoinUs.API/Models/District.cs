using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class District
    {
        public int DistrictId { get; set; }
        public int? DistrictCode { get; set; }
        public string DistrictTh { get; set; }
        public string DistrictEn { get; set; }
        public int? ProvinceId { get; set; }
    }
}