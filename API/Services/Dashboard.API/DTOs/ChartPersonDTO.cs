using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.DTOs
{
    public class ChartPersonDTO
    {
        public string name { get; set; }
        public int quater { get; set; }
        public List<int> pie { get; set; }
        public List<string> nameOfPie { get; set; }
        public int names { get; set; }
    public ChartPersonDTO()
    {
        nameOfPie = new List<string>();
        pie = new List<int>();
    }
    }
    
}
