using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class Position
    {
        public int PositionId { get; set; }
        public string Position1 { get; set; }
        public string Active { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
        public string IconPosition { get; set; }
        public string Address { get; set; }
    }
}