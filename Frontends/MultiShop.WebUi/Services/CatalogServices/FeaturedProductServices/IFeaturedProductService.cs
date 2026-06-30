using MultiShop.DtoLayer.FeaturedProductsDtos;

namespace MultiShop.WebUi.Services.CatalogServices.FeaturedProductServices
{
    public interface IFeaturedProductService
    {
        Task<List<ResultFeaturedProductDto>> GetAllFeaturedProductAsync();
        Task CreateFeaturedProductAsync(CreateFeaturedProductDto createFeaturedProductDto);
        Task UpdateFeaturedProductAsync(UpdateFeaturedProductDto updateFeaturedProductDto);
        Task DeleteFeaturedProductAsync(string id);
        Task<GetFeaturedProductByIdDto> GetFeaturedProductByIdAsync(string id);
    }
}
