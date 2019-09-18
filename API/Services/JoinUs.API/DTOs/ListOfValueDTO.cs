using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterManange.API.DTOs
{
    public class ListOfValueDTO
    {
        public string GroupCode { get; set; }
        public int? SeqNo { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
        public string Active { get; set; }
    }
}
