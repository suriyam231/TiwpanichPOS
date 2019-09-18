using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterManange.API.DTOs
{
    public class PositionDTO
    {
        public int id { get; set; }
        public int? PositionId { get; set; }
        public string Position { get; set; }
        public string Active { get; set; }
        public int? NumberOfPosition { get; set; }
        public string ActiveStatus { get; set; }
        public string IconPosition { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Type_Employee { get; set; }
        public string Value { get; set; }
    }
}
