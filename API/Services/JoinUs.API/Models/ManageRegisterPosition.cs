using System;
using System.Collections.Generic;

namespace RegisterManange.API.Models
{
    public partial class ManageRegisterPosition
    {
        public int Id { get; set; }
        public int? PositionId { get; set; }
        public int? NumberOfPosition { get; set; }
        public string ActiveStatus { get; set; }
        public string CrBy { get; set; }
        public DateTime? CrDate { get; set; }
        public string UpdBy { get; set; }
        public DateTime? UpdDate { get; set; }
        public string TypeEmployee { get; set; }
    }
}