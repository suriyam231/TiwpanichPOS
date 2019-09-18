using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.DTOs
{
    public class QuaterMonthDTO
    {
        public string name { get; set; }
        public int quater { get; set; }
        public List<int> pie { get; set; }
        public List<string> nameOfPie { get; set; }
        
        public QuaterMonthDTO()
        {
            nameOfPie = new List<string>();
            pie = new List<int>();
        }
    }
}
