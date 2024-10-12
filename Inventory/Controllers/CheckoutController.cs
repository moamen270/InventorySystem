using BL.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICheckoutService _checkoutService;

        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        public async Task<IActionResult> Index()
        {
            var session = await _checkoutService.CheckoutAsync();

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        public async Task<IActionResult> Checkout(List<int> productIds)
        {
            var session = await _checkoutService.CheckoutAsync(productIds);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        public IActionResult Confirm(int id)
        {
            return Ok(id);
        }

        public IActionResult Deny(int id)
        {
            return BadRequest(id);
        }
    }
}