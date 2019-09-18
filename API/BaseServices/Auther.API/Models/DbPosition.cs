using System;
using System.Collections.Generic;

namespace Auther.API.Models
{
    public partial class DbPosition
    {
        public string PositonCode { get; set; }
        public string DepartmentGroup { get; set; }
        public string PositionName { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
        public int PositionNo { get; set; }
        public int? SeqNo { get; set; }
    }
}