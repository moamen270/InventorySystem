using BL.Service.Interfaces;
using Models.Entities;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Service
{
    public class PaymentService : IPaymentService
    {
        public Session ProcessPayment(Order order)
        {
            var options = sessionCreateOptions(order.Id);
            var sessionItems = CreatePaymentList(order.OrderItems);
            options.LineItems.AddRange(sessionItems);

            var service = new SessionService();
            Session session = service.Create(options);
            return session;
        }

        private SessionCreateOptions sessionCreateOptions(int orderId)
        {
            var domain = "https://localhost:44339/";

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = domain + $"Order/Confirm?id={orderId}",
                CancelUrl = domain + $"Order/Deny?id={orderId}",
            };
            return options;
        }

        private List<SessionLineItemOptions> CreatePaymentList(ICollection<OrderItem> orderItems)
        {
            var sessionLineItems = new List<SessionLineItemOptions>();
            foreach (var orderItem in orderItems)
            {
                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(orderItem.UnitPrice * 100),//20.00 -> 2000
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = orderItem.Product.Name,
                            Description = orderItem.Product.Description,
                            //Images = new List<string> { orderItem.Product.ImageUrl }
                        },
                    },
                    Quantity = orderItem.Quantity,
                };
                sessionLineItems.Add(sessionLineItem);
            }
            return sessionLineItems;
        }
    }
}