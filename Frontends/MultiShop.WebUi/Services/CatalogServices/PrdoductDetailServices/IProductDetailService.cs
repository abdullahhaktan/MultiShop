using MultiShop.DtoLayer.ProductDetailDtos;

namespace MultiShop.WebUi.Services.CatalogServices.PrdoductDetailServices
{
    public interface IProductDetailService
    {
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task<GetProductDetailByIdDto> GetProductDetailByIdAsync(string id);
    }
}
