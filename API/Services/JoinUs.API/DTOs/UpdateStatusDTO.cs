using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterManange.API.DTOs
{
    public class UpdateStatusDTO
    {
        public int ID { get; set; }
        public int[] IDs { get; set; } 
        public string Status { get; set; }
        public string UpdBy { get; set; }
    }
}
