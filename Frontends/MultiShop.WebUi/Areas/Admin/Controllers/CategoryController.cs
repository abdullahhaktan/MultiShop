using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CategoryDtos;
using MultiShop.WebUi.Services.CatalogServices.CategoryServices;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        private async Task getRoutingsAsync()
        {
            try
            {
                HttpContext.Items["v0"] = "Kategori İşlemleri";
                HttpContext.Items["v1"] = "Kategori Listesi";
                HttpContext.Items["v2"] = "/Admin/Category/Index";
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

                var values = await _categoryService.GetAllCategoryAsync();
                if (values == null)
                    return View(new List<ResultCategoryDto>());

                return View(values);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            try
            {
                await getRoutingsAsync();
                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            try
            {
                if (createCategoryDto == null)
                    return View("Error");

                await _categoryService.CreateCategoryAsync(createCategoryDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> DeleteCategory(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await _categoryService.DeleteCategoryAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await getRoutingsAsync();
                var value = await _categoryService.GetCategoryByIdAsync(id);
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
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                if (updateCategoryDto == null)
                    return View("Error");

                await _categoryService.UpdateCategoryAsync(updateCategoryDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

    }
}