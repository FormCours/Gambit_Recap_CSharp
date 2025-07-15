using Demo_10_Testing.App.Exceptions;
using Demo_10_Testing.App.Interfaces;
using Demo_10_Testing.App.Models;

namespace Demo_10_Testing.App.Services
{
    public class OrderService : IOrderService
    {
        private readonly IStockService _stockService;
        private List<Order> _orders;

        public OrderService(IStockService stockService)
        {
            _stockService = stockService;
            _orders = new List<Order>();
        }


        public IEnumerable<Order> Orders
        {
            get { return _orders.AsReadOnly(); }
        }


        public Order Create()
        {
            Order order = new Order();
            _orders.Add(order);
            return order;
        }

        public bool AddProduct(int orderId, int productId, int quantity)
        {
            Order? order = _orders.SingleOrDefault(o => o.OrderId == orderId);
            if(order is null)
            {
                throw new OrderNotFoundException($"Order {orderId} not found");
            }

            Product? p = _stockService.GetProductById(productId);
            if(p is null)
            {
                throw new Exception($"Product {productId} not found");
            }

            
            //TODO Refactor this (╯°□°）╯︵ ┻━┻
            Order.OrderLine? existingOrderLine = order.OrderLines.SingleOrDefault(ol => ol.Product.ProductId == productId);
            if (existingOrderLine is not null)
            {
                existingOrderLine.Quantity += quantity;
            }
            else
            {
                order.OrderLines.Add(new Order.OrderLine()
                {
                    Product = p,
                    Quantity = quantity
                });
            }

            return true;
        }

        public bool Validate(int orderId)
        {
            Order? order = _orders.SingleOrDefault(o => o.OrderId == orderId);
            if (order is null)
            {
                throw new OrderNotFoundException($"Order {orderId} not found");
            }

            return order.OrderLines.All(ol => _stockService.GetQuantity(ol.Product.ProductId) >= ol.Quantity);
        }

        public bool Send(int orderId)
        {
            if(!Validate(orderId))
            {
                throw new OrderInvalidException($"Order {orderId} is invalide !");
            }

            Order order = _orders.Single(o => o.OrderId == orderId);
            order.OrderLines.ForEach(ol => {
                _stockService.RemoveQuantity(ol.Product.ProductId, ol.Quantity);
            });

            return true;
        }
    }
}
