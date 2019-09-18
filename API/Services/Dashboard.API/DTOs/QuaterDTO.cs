using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.DTOs
{
    public class QuaterDTO
    {
        public string name { get; set; }
        public int quater { get; set; }
        public List<int> pie { get; set; }
        public List<string> nameOfPie { get; set; }

        public QuaterDTO()
        {
            nameOfPie = new List<string>();
            pie = new List<int>();
        }
    }
}
