using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.API.DTOs
{
    public partial class ProductDTO
    {
        public float CostPrice { get; set; }
        public float ProductAmount { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public string ProductReference { get; set; }
        public string TypeID { get; set; }

    }
}
