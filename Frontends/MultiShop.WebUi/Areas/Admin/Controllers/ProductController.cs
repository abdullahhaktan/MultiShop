using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.ProductDtos;
using MultiShop.WebUi.Services.CatalogServices.CategoryServices;
using MultiShop.WebUi.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                var values = await _categoryService.GetAllCategoryAsync();
                if (values == null)
                    ViewBag.Categories = null;

                ViewBag.Categories = values;
            }
            catch (Exception ex)
            {
                ViewBag.Categories = $"Kategorileri çekme esnasında bir problem oluştu.+ {ex.Message}";
            }
        }

        private async Task getRoutingsAsync()
        {
            try
            {
                HttpContext.Items["v0"] = "Ürün İşlemleri";
                HttpContext.Items["v1"] = "Ürün Listesi";
                HttpContext.Items["v2"] = "/Admin/Product/Index";
            }
            catch (Exception ex)
            {
                throw new Exception("getRoutingsAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                await getRoutingsAsync();
                var values = await _productService.GetAllProductWithCategoryAsync();
                if (values == null)
                    return View(new List<ResultProductWithCategoryDto>());

                return View(values);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            try
            {
                await LoadCategoriesAsync();
                await getRoutingsAsync();

                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductDto createProductDto)
        {
            try
            {
                if (createProductDto == null)
                    return View("Error");

                await _productService.CreateProductAsync(createProductDto);
                await LoadCategoriesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await _productService.DeleteProductAsync(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await LoadCategoriesAsync();
                await getRoutingsAsync();

                var value = await _productService.GetProductByIdAsync(id);
                if (value == null)
                    return View("Error");

                return View(value);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            try
            {
                if (updateProductDto == null)
                    return View("Error");

                await _productService.UpdateProductAsync(updateProductDto);

                await LoadCategoriesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

    }
}