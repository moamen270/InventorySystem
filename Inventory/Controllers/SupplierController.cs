using BL.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace Inventory.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly IProductService _productService;

        public SupplierController(ISupplierService supplierService, IProductService productService)
        {
            _supplierService = supplierService;
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();
            return View(suppliers);
        }
/*        public async Task<IActionResult> Details(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null) return NotFound();

            *//*var products = await _productService.GetProductsByIdAsync(id);
            ViewBag.Products = products;  *//*

            return View(supplier);
        }*/

        public async Task<IActionResult> Details(int id)
        {
            var supplier = await _supplierService.GetSupplierWithProductsByIdAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                await _supplierService.AddSupplierAsync(supplier);
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null) return NotFound();
            return View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Supplier supplier)
        {
            if (id != supplier.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _supplierService.UpdateSupplierAsync(supplier);
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null) return NotFound();
            return View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            await _supplierService.DeleteSupplierAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
