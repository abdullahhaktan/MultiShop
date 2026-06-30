using MultiShop.DtoLayer.ProductDetailDtos;
using MultiShop.DtoLayer.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;
        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            if (createProductImageDto == null)
                throw new ArgumentNullException(nameof(createProductImageDto));

            try
            {
                await _httpClient.PostAsJsonAsync<CreateProductImageDto>("productImages", createProductImageDto);
            }
            catch (Exception ex)
            {
                throw new Exception("CreateProductImageAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task DeleteProductImageAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                await _httpClient.DeleteAsync($"productImages/{id}");
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteProductImageAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            try
            {
                var responseMessage = await _httpClient.GetAsync("productImages");

                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(jsonData))
                    return new List<ResultProductImageDto>();

                var values = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);

                if (values == null)
                    return new List<ResultProductImageDto>();

                return values;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllProductImageAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<GetProductImageByIdDto> GetProductImageByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                var responseMessage = await _httpClient.GetAsync("productImages/" + id);
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var value = await responseMessage.Content.ReadFromJsonAsync<GetProductImageByIdDto>();
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception("GetProductImageByIdAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            if (updateProductImageDto == null)
                throw new ArgumentNullException(nameof(updateProductImageDto));

            try
            {
                await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("productImages", updateProductImageDto);
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateProductImageAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }
    }
}
