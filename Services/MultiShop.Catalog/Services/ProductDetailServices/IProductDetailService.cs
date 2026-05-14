using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetails();
        Task CreateProductDetailAsync(CreateProductDetailDto productDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto productDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByProductDetailIdDto> GetByProductDetailIdAsync(string id);
    }
}
