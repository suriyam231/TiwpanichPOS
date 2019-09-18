using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class ListOfValueGroups
    {
        public string GroupCode { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
        public string Active { get; set; }
    }
}