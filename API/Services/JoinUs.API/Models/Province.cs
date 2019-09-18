using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class Province
    {
        public int ProvinceId { get; set; }
        public int? ProvinceCode { get; set; }
        public string ProvinceTh { get; set; }
        public string ProvinceEn { get; set; }
    }
}