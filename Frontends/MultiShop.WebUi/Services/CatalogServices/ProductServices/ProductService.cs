using MultiShop.DtoLayer.ProductDtos;
using MultiShop.WebUi.Services.Catalog_Services.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.Catalog_Services.CategoryServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            if (createProductDto == null)
                throw new ArgumentNullException(nameof(createProductDto));

            try
            {
                await _httpClient.PostAsJsonAsync("products", createProductDto);
            }
            catch (Exception ex)
            {
                throw new Exception("CreateProductAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task DeleteProductAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                await _httpClient.DeleteAsync($"products/{id}");
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteProductAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            try
            {
                var responseMessage = await _httpClient.GetAsync("products");
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(jsonData))
                    return new List<ResultProductDto>();

                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                if (values == null)
                    return new List<ResultProductDto>();

                return values;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllProductAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            try
            {
                var responseMessage = await _httpClient.GetAsync("products");
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(jsonData))
                    return new List<ResultProductWithCategoryDto>();

                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                if (values == null)
                    return new List<ResultProductWithCategoryDto>();

                return values;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllProductWithCategoryAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryByCategoryIdAsync(string categoryId)
        {
            try
            {
                var responseMessage = await _httpClient.GetAsync($"products/GetByCategory/{categoryId}");
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(jsonData))
                    return new List<ResultProductWithCategoryDto>();

                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                if (values == null)
                    return new List<ResultProductWithCategoryDto>();

                return values;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllProductWithCategoryByCategoryIdAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<GetProductByIdDto> GetProductByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                var responseMessage = await _httpClient.GetAsync("products/" + id);
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var value = await responseMessage.Content.ReadFromJsonAsync<GetProductByIdDto>();
                if (value == null)
                    throw new Exception("Ürün bulunamadı.");

                return value;
            }
            catch (Exception ex)
            {
                throw new Exception("GetProductByIdAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            if (updateProductDto == null)
                throw new ArgumentNullException(nameof(updateProductDto));

            try
            {
                await _httpClient.PutAsJsonAsync("products", updateProductDto);
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateProductAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }
    }
}