// RegisterController.cs (Güncel)
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.RegisterDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUi.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createRegisterDto);
            }

            try
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createRegisterDto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5001/api/Registers", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["RegisterSuccess"] = "🎉 Hesabınız başarıyla oluşturuldu! Giriş yapabilirsiniz.";
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    var error = await responseMessage.Content.ReadAsStringAsync();
                    TempData["RegisterError"] = "❌ Kayıt başarısız: " + error;
                    return View(createRegisterDto);
                }
            }
            catch (Exception ex)
            {
                TempData["RegisterError"] = "❌ Bir hata oluştu: " + ex.Message;
                return View(createRegisterDto);
            }
        }
    }
}