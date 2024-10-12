using Models.Entities;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Service.Interfaces
{
    public interface ICheckoutService
    {
        Task<Session> CheckoutAsync();

        Task<Session> CheckoutAsync(List<int> productIds);
    }
}