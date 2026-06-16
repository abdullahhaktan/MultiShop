using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.ProductDetailDtos;
using MultiShop.DtoLayer.ProductDtos;
using MultiShop.DtoLayer.ProductImageDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class ProductImageController(IHttpClientFactory _httpClientFactory) : Controller
    {
        private async Task LoadProductsAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Products");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                ViewBag.Products = products;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpContext.Items["v0"] = "Ürün Görsel İşlemleri";
            HttpContext.Items["v1"] = "Ürün Görsel Listesi";
            HttpContext.Items["v2"] = "/Admin/ProductImage/Index";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/ProductImages");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductImageWithProductDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProductImage()
        {
            await LoadProductsAsync();

            HttpContext.Items["v0"] = "Ürün Görsel İşlemleri";
            HttpContext.Items["v1"] = "Ürün Görsel Ekleme";
            HttpContext.Items["v2"] = "/Admin/ProductImage/Index";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage([FromForm] CreateProductImageDto createProductImageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductImageDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/ProductImages", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProductImage", new { area = "Admin" });
            }

            await LoadProductsAsync();
            return View();
        }

        public async Task<IActionResult> DeleteProductImage(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/ProductImages/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProductImage", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetProductImageIdByProductId(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/ProductImages/GetProductImageIdByProductId/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var productImageId = await responseMessage.Content.ReadAsStringAsync();
                return RedirectToAction("UpdateProductImage", new { id = productImageId });
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProductImage(string id)
        {
            await LoadProductsAsync();

            HttpContext.Items["v0"] = "Ürün Görsel İşlemleri";
            HttpContext.Items["v1"] = "Ürün Görsel Güncelleme";
            HttpContext.Items["v2"] = "/Admin/ProductImage/Index";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/ProductImages/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetProductImageByIdDto>(jsonData);
                return View(value);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductImageDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/ProductImages", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProductImage", new { area = "Admin" });
            }

            await LoadProductsAsync();
            return View();
        }

    }
}
