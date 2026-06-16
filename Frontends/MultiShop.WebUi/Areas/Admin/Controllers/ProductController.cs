using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CategoryDtos;
using MultiShop.DtoLayer.ProductDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class ProductController(IHttpClientFactory _httpClientFactory) : Controller
    {
        private async Task LoadCategoriesAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                ViewBag.Categories = categories;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpContext.Items["v0"] = "Ürün İşlemleri";
            HttpContext.Items["v1"] = "Ürün Listesi";
            HttpContext.Items["v2"] = "/Admin/Product/Index";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Products");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            await LoadCategoriesAsync();

            HttpContext.Items["v0"] = "Ürün İşlemleri";
            HttpContext.Items["v1"] = "Ürün Ekleme";
            HttpContext.Items["v2"] = "/Admin/Product/Index";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/Products", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }

            await LoadCategoriesAsync();
            return View();
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/Products/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            await LoadCategoriesAsync();


            HttpContext.Items["v0"] = "Ürün İşlemleri";
            HttpContext.Items["v1"] = "Ürün Güncelleme";
            HttpContext.Items["v2"] = "/Admin/Product/Index";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/Products/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetProductByIdDto>(jsonData);
                return View(value);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/Products", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }

            await LoadCategoriesAsync();
            return View();
        }

    }
}