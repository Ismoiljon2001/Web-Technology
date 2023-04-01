using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAD_CW_11064.Models
{
    public class Product
    {
     

        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public string ProductType { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public int Prize { get; set; }
        public Product ProductOrder { get; set; }

    }
}
