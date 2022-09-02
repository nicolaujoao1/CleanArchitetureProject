using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArch.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList
                (
                  await _categoryService.GetCategories(),"Id","Name"
                );
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDto)
        {
          if(!ModelState.IsValid)return View(productDto);
            await _productService.Add(productDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO productDto)
        {
            if (!ModelState.IsValid) return View(productDto);
            await _productService.Update(productDto);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet()]
        public async Task<IActionResult> Edit(int id)
        {
            var productDto = await _productService.GetById(id);
            if (productDto is null) return NotFound();
            var categories = await _categoryService.GetCategories();

            ViewBag.CategoryId = new SelectList(
                categories, "Id", "Name", productDto.CategoryId
                );
            return View(productDto);
        }
    }
}
