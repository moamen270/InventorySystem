using BL.Service.Interfaces;
using DAL.UnitOfWork;
using Models.Entities;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Service
{
    public class CheckoutService : ICheckoutService
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IProductService _productService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;

        public CheckoutService(
            IOrderService orderService,
            IOrderItemService orderItemService,
            IProductService productService,
            IUnitOfWork unitOfWork,
            IPaymentService paymentService
            )
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
            _productService = productService;
            _unitOfWork = unitOfWork;
            _paymentService = paymentService;
        }

        public async Task<Session> CheckoutAsync()
        {
            // Create order
            var order = new Order();
            await _orderService.AddOrder(order);
            await _unitOfWork.SaveAsync();
            // Create order items
            var products = (await _productService.GetAllProductsAsync()).Take(2);
            var orderItem1 = new OrderItem
            {
                OrderId = order.Id,
                ProductId = products.First().Id,
                Quantity = 1,
                Product = products.First()
            };
            var orderItem2 = new OrderItem
            {
                OrderId = order.Id,
                ProductId = products.Last().Id,
                Quantity = 2,
                Product = products.Last()
            };
            await _orderItemService.AddOrderItem(orderItem1);
            await _orderItemService.AddOrderItem(orderItem2);
            await _unitOfWork.SaveAsync();

            order.OrderItems = new List<OrderItem> { orderItem1, orderItem2 };

            // Process payment
            var session = _paymentService.ProcessPayment(order);
            return session;
        }

        public async Task<Session> CheckoutAsync(List<int> productIds)
        {
            var order = new Order();
            await _orderService.AddOrder(order);
            var orderItems = new List<OrderItem>();
            foreach (var productId in productIds)
            {
                var product = await _productService.GetProductByIdAsync(productId);
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = productId,
                    Quantity = 1,
                    Product = product
                };
                await _orderItemService.AddOrderItem(orderItem);
                orderItems.Add(orderItem);
            }
            order.OrderItems = orderItems;
            // Process payment
            var session = _paymentService.ProcessPayment(order);
            return session;
        }
    }
}