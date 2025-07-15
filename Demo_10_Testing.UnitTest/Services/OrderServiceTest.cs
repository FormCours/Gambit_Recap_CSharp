using Demo_10_Testing.App.Interfaces;
using Demo_10_Testing.App.Models;
using Demo_10_Testing.App.Services;
using Demo_10_Testing.UnitTest.Fakes;
using FluentAssertions;
using Moq;

namespace Demo_10_Testing.UnitTest.Services
{
    public class OrderServiceTest
    {
        [Fact]
        public void Create_NewOrder_ReturnOrdreCreated()
        {
            // Mocking
            // - Stub : Un "Fake" dépendence necessaire au test, mais non utilisé dans les asserts.
            // - Mock : Un "Fake" dépendence utilisé lors du test et des asserts.
            Mock<IStockService> stubStockService = new Mock<IStockService>();

            // Arrange
            OrderService orderService = new OrderService(stubStockService.Object);

            // Action
            Order actual = orderService.Create();

            // Assert
            actual.Should().BeOfType<Order>();
            actual.OrderLines.Should().BeEmpty();
        }

        [Fact]
        public void AddProduct_ProductInStock_OrderLineCreated_Stub()
        {
            // Mocking
            IStockService stubStockService = new FakeStockService_WithProductInStock();

            // Arrange
            OrderService orderService = new OrderService(stubStockService);
            Order order = orderService.Create();

            // Action
            orderService.AddProduct(order.OrderId, 2, 10);

            // Assert
            order.OrderLines.Should().HaveCount(1);
        }

        [Fact]
        public void AddProduct_ProductInStock_OrderLineCreated_Mock()
        {
            int productId = 2;
            int quantity = 10;

            // Mocking
            Mock<IStockService> mockStockService = new Mock<IStockService>();
            //mockStockService.Setup(service => service.GetQuantity(productId))
            //                .Returns(101);
            mockStockService.Setup(service => service.GetProductById(productId))
                            .Returns(new Product() { ProductId = 2, Name = "Fraise", Price = 6m });

            // Arrange
            OrderService orderService = new OrderService(mockStockService.Object);
            Order order = orderService.Create();

            // Action
            orderService.AddProduct(order.OrderId, productId, quantity);

            // Assert
            mockStockService.Verify(service => service.GetProductById(productId), Times.Once);
        }

    }
}
