using MultiShop.Catalog.Dtos.FeaturedProductDtos;

namespace MultiShop.Catalog.Services.FeaturedProductServices
{
    public interface IFeaturedProductService
    {
        Task<List<ResultFeaturedProductDto>> GetAllFeaturedProductsAsync();
        Task CreateFeaturedProductAsync(CreateFeaturedProductDto createFeaturedProductDto);
        Task UpdateFeaturedProductAsync(UpdateFeaturedProductDto updateFeaturedProductDto);
        Task DeleteFeaturedProductAsync(string id);
        Task<GetFeaturedProductByIdDto> GetFeaturedProductByIdAsync(string id);
    }
}
