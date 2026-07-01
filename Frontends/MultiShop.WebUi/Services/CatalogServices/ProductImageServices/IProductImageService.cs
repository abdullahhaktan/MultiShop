using MultiShop.DtoLayer.ProductImageDtos;

namespace MultiShop.WebUi.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageWithProductDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetProductImageByIdDto> GetProductImageByIdAsync(string id);
        Task<string> GetProductImageIdByProductIdAsync(string id);
    }
}
