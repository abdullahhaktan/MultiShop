using MultiShop.DtoLayer.ProductDetailDtos;
using MultiShop.DtoLayer.ProductImageDtos;

namespace MultiShop.WebUi.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetProductImageByIdDto> GetProductImageByIdAsync(string id);
    }
}
