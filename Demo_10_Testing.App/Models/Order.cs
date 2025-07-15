using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_10_Testing.App.Models
{
    public class Order
    {
        public class OrderLine
        {
            public Product Product { get; set; }
            public int Quantity { get; set; }
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<OrderLine> OrderLines { get; set; } = [];
    }
}
