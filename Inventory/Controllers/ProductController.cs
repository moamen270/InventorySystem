using BL.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Entities;

namespace Inventory.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISupplierService _supplierService;

        public ProductController(IProductService productService, ISupplierService supplierService)
        {
            _productService = productService;
            _supplierService = supplierService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            ViewBag.Suppliers = new SelectList(await _supplierService.GetAllSuppliersAsync(), "Id", "Name");

            return View(products);
        }

        [HttpGet("Details")]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Suppliers = new SelectList(await _supplierService.GetAllSuppliersAsync(), "Id", "Name");
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddProductAsync(product);

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.Suppliers = new SelectList(await _supplierService.GetAllSuppliersAsync(), "Id", "Name", product.Id);

            return View(product);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _productService.UpdateProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}