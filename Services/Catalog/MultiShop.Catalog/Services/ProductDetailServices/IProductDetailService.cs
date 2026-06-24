using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task UpdateProductDetailAsync(UpdateProductDetailDto productDetailDto);
        Task<GetProductDetailByIdDto> GetByProductDetailIdAsync(string id);
    }
}
