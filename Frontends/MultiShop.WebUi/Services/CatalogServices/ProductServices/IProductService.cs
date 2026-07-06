using MultiShop.DtoLayer.ProductDtos;

namespace MultiShop.WebUi.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetProductByIdDto> GetProductByIdAsync(string id);
        Task<string> GetProductIdByProductNameAsync(string productName);
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryByCategoryIdAsync(string categoryId);
    }
}
