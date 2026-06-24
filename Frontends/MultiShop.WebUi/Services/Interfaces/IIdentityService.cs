using MultiShop.DtoLayer.LoginDtos;

namespace MultiShop.WebUi.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signUpDto);
    }
}
