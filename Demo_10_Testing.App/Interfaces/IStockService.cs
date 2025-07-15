using Demo_10_Testing.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_10_Testing.App.Interfaces
{
    public interface IStockService
    {
        IEnumerable<Product> Products { get; }

        Product? GetProductById(int id);
        int GetQuantity(int productId);
        int AddQuantity(int productId, int quantity);
        int RemoveQuantity(int productId, int quantity);
    }
}
