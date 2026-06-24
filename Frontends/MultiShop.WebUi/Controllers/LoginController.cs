using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.LoginDtos;
using MultiShop.WebUi.Services.Interfaces;
using MultiShop.WebUi.Services.LoginServices;

namespace MultiShop.WebUi.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly IIdentityService _identityService;

        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(createLoginDto);
        //    }

        //    try
        //    {
        //        var client = _httpClientFactory.CreateClient();
        //        StringContent content = new StringContent(JsonConvert.SerializeObject(createLoginDto), Encoding.UTF8, "application/json");
        //        var responseMessage = await client.PostAsync("http://localhost:5001/api/Logins", content);

        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //            var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
        //            {
        //                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        //            });

        //            if(tokenModel != null)
        //            {
        //                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        //                var token = handler.ReadJwtToken(tokenModel.Token);
        //                var claims = token.Claims.ToList();

        //                if(tokenModel.Token != null)
        //                {
        //                    claims.Add(new Claim("multishoptoken", tokenModel.Token));
        //                    var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
        //                    var authProps = new AuthenticationProperties
        //                    {
        //                        ExpiresUtc = tokenModel.ExpireDate,
        //                        IsPersistent = true,
        //                    };

        //                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
        //                    return RedirectToAction("Index","Default");
        //                }
        //            }

        //            TempData["LoginSuccess"] = "🎉 Giriş Başarılı.";
        //            return RedirectToAction("Index", "Default");
        //        }
        //        else
        //        {
        //            var errorJson = await responseMessage.Content.ReadAsStringAsync();

        //            try
        //            {
        //                var errorObj = JsonSerializer.Deserialize<Dictionary<string, string>>(errorJson);

        //                if (errorObj != null && errorObj.ContainsKey("message"))
        //                {
        //                    TempData["LoginError"] = $"❌ {errorObj["message"]}";
        //                }
        //                else
        //                {
        //                    TempData["LoginError"] = "❌ Kullanıcı adı veya şifre hatalı.";
        //                }
        //            }
        //            catch
        //            {
        //                TempData["LoginError"] = "❌ Giriş başarısız. Lütfen bilgilerinizi kontrol edin.";
        //            }

        //            return View(createLoginDto);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["LoginError"] = "❌ Bir hata oluştu: " + ex.Message;
        //        return View(createLoginDto);
        //    }
        //}

        //[HttpGet]
        //public IActionResult SignIn()
        //{
        //    return View();
        //}

        //[HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signUpDto)
        {
            signUpDto.UserName = "ahmethaktan";
            signUpDto.Password = "Ahmethaktan1.";
            await _identityService.SignIn(signUpDto);
            return RedirectToAction("Index", "Login");
        }
    }
}
