using MultiShop.Catalog.Dtos.AboutDtos;

namespace MultiShop.Catalog.Services.AboutServices
{
    public interface IAboutService
    {
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task CreateAboutAsync(CreateAboutDto createAboutDto);
        Task<GetAboutByIdDto> GetByIdAsync();
    }
}
