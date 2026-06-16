using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.FeaturedProductsDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class FeaturedProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeaturedProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpContext.Items["v0"] = "Öne Çıkan Ürün İşlemleri";
            HttpContext.Items["v1"] = "Öne Çıkan Ürün Ekleme";
            HttpContext.Items["v2"] = "/Admin/FeaturedProduct/Index";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/FeaturedProducts");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeaturedProductDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateFeaturedProduct()
        {
            HttpContext.Items["v0"] = "Öne Çıkan Ürün İşlemleri";
            HttpContext.Items["v1"] = "Öne Çıkan Ürün Ekleme";
            HttpContext.Items["v2"] = "/Admin/FeaturedProduct/Index";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeaturedProduct(CreateFeaturedProductDto createFeaturedProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFeaturedProductDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/FeaturedProducts", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeaturedProduct", new { area = "Admin" });
            }

            return View();
        }

        public async Task<IActionResult> DeleteFeaturedProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/FeaturedProducts/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeaturedProduct", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeaturedProduct(string id)
        {
            HttpContext.Items["v0"] = "Öne Çıkan Ürün İşlemleri";
            HttpContext.Items["v1"] = "Öne Çıkan Ürün Güncelleme";
            HttpContext.Items["v2"] = "/Admin/FeaturedProduct/Index";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/FeaturedProducts/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetFeaturedProductByIdDto>(jsonData);
                return View(value);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeaturedProduct(UpdateFeaturedProductDto updateFeaturedProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFeaturedProductDto);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/FeaturedProducts", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
