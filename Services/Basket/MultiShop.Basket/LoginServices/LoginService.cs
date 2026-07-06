using MultiShop.Basket.Dtos;
using System.Security.Claims;

namespace MultiShop.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient _httpClient;

        public LoginService(IHttpContextAccessor contextAccessor, HttpClient httpClient)
        {
            _httpContextAccessor = contextAccessor;
            _httpClient = httpClient;
        }

        public async Task<UserDetailViewModel> GetUserInfo()
        {
            return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuserinfo");
        }

        public string GetUserId
        {
            get
            {
                Console.WriteLine("========== USER DEBUG ==========");

                var user = _httpContextAccessor.HttpContext?.User;

                Console.WriteLine($"HttpContext Null: {_httpContextAccessor.HttpContext == null}");
                Console.WriteLine($"User Null: {user == null}");
                Console.WriteLine($"Authenticated: {user?.Identity?.IsAuthenticated}");
                Console.WriteLine($"AuthenticationType: {user?.Identity?.AuthenticationType}");
                Console.WriteLine($"Name: {user?.Identity?.Name}");

                if (user != null)
                {
                    foreach (var claim in user.Claims)
                    {
                        Console.WriteLine($"{claim.Type} = {claim.Value}");
                    }
                }

                var userId =
                    user?.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
                    user?.FindFirst("sub")?.Value ??
                    user?.FindFirst("nameid")?.Value ??
                    string.Empty;

                Console.WriteLine($"Resolved UserId: {userId}");
                Console.WriteLine("================================");

                return userId;
            }
        }
    }
}