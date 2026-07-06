using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.LoginServices
{
    public interface ILoginService
    {
        public string GetUserId { get; }
        Task<UserDetailViewModel> GetUserInfo();
    }
}
