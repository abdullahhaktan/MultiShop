using MultiShop.DtoLayer.BrandDtos;

namespace MultiShop.WebUi.Services.CatalogServices.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task CreateBrandAsync(CreateBrandDto createBrandDto);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task DeleteBrandAsync(string id);
        Task<GetBrandByIdDto> GetBrandByIdAsync(string id);
    }
}
