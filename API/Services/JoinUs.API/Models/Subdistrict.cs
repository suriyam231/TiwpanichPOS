using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class Subdistrict
    {
        public int SubdistrictId { get; set; }
        public int? SubdistrictCode { get; set; }
        public string SubdistrictTh { get; set; }
        public string SubdistrictEn { get; set; }
        public int? DistrictId { get; set; }
        public int? ProvinceId { get; set; }
    }
}