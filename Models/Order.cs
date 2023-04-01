using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAD_CW_11064.Models
{
    public class Order
    {
     

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ClientId { get; set; }
        public int Quantity { get; set; }
    }
}
