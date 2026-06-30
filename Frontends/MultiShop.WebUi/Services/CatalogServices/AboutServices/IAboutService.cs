using MultiShop.DtoLayer.AboutDtos;

namespace MultiShop.WebUi.Services.CatalogServices.AboutServices
{
    public interface IAboutService
    {
        Task CreateAboutAsync(CreateAboutDto createAboutDto);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task DeleteAboutAsync(string id);
        Task<GetAboutByIdDto> GetAboutByIdAsync();
    }
}
