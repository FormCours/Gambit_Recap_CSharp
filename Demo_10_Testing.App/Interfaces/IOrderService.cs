using Demo_10_Testing.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_10_Testing.App.Interfaces
{
    public interface IOrderService
    {
        public IEnumerable<Order> Orders { get; }

        Order Create();
        bool AddProduct(int orderId, int productId, int quantity);
        bool Validate(int orderId);
        bool Send(int orderId);
    }
}
