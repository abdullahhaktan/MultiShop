using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.UserCommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUi.Controllers
{
    public class ProductListController(IHttpClientFactory _httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index(string id)
        {
            HttpContext.Items["v0"] = "Ana Sayfa";
            HttpContext.Items["v1"] = "Ürün İşlemleri";
            HttpContext.Items["v2"] = "Ürün Listesi";

            HttpContext.Items["a0"] = "/Default/Index";
            HttpContext.Items["a1"] = "/ProductList/Index";

            ViewBag.categoryId = id;
            return View();
        }

        public async Task<IActionResult> ProductDetail(string id)
        {
            HttpContext.Items["v0"] = "Ana Sayfa";
            HttpContext.Items["v1"] = "Ürün İşlemleri";
            HttpContext.Items["v2"] = "Ürün Detayı";

            HttpContext.Items["a0"] = "/Default/Index";
            HttpContext.Items["a1"] = "/ProductList/Index";

            ViewBag.id = id;
            return View();
        }

        public async Task<IActionResult> CreateComment(CreateUserCommentDto createUserCommentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createUserCommentDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7095/api/UserComments", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductDetail", new { id = createUserCommentDto.ProductId });
            }

            return View();
        }
    }
}
