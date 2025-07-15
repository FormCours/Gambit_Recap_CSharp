using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_10_Testing.App.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
    }
}
