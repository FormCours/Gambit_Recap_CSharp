using Demo_10_Testing.App.Interfaces;
using Demo_10_Testing.App.Models;

namespace Demo_10_Testing.UnitTest.Fakes
{
    public class FakeStockService_WithProductInStock : IStockService
    {
        private IDictionary<int, int> _stockProducts = new Dictionary<int, int>()
        {
            { 1, 42 },
            { 2, 101 },
            { 3, 15 }
        };

        public IEnumerable<Product> Products => [
            new Product() { ProductId= 1, Name="Pomme", Price= 3.5m },
            new Product() { ProductId= 2, Name="Fraise", Price= 6m },
            new Product() { ProductId= 3, Name="Melon", Price= 11.99m },
        ];

        public Product? GetProductById(int id)
        {
            return Products.SingleOrDefault(p => p.ProductId == id);
        }

        public int GetQuantity(int productId)
        {
            _stockProducts.TryGetValue(productId, out int result);
            return result;
        }


        public int AddQuantity(int productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public int RemoveQuantity(int productId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
