using Models.Entities;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Service.Interfaces
{
    public interface IPaymentService
    {
        Session ProcessPayment(Order order);
    }
}