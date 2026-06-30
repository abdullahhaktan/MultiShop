using MultiShop.DtoLayer.FeaturedProductsDtos;
using MultiShop.WebUi.Services.CatalogServices.FeaturedProductServices;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.CatalogServices.FeaturedProductdProductServices
{
    public class FeaturedProductService : IFeaturedProductService
    {
        private readonly HttpClient _httpClient;
        public FeaturedProductService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task CreateFeaturedProductAsync(CreateFeaturedProductDto createFeaturedProductDto)
        {
            if (createFeaturedProductDto == null)
                throw new ArgumentNullException(nameof(createFeaturedProductDto));

            try
            {
                await _httpClient.PostAsJsonAsync<CreateFeaturedProductDto>("features", createFeaturedProductDto);
            }
            catch (Exception ex)
            {
                throw new Exception("CreateFeaturedProductAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task DeleteFeaturedProductAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                await _httpClient.DeleteAsync($"features/{id}");
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteFeaturedProductAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<List<ResultFeaturedProductDto>> GetAllFeaturedProductAsync()
        {
            try
            {
                var responseMessage = await _httpClient.GetAsync("features");
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(jsonData))
                    return new List<ResultFeaturedProductDto>();

                var values = JsonConvert.DeserializeObject<List<ResultFeaturedProductDto>>(jsonData);
                return values;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllFeaturedProductAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<GetFeaturedProductByIdDto> GetFeaturedProductByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                var responseMessage = await _httpClient.GetAsync("features/" + id);
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var value = await responseMessage.Content.ReadFromJsonAsync<GetFeaturedProductByIdDto>();
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception("GetFeaturedProductByIdAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task UpdateFeaturedProductAsync(UpdateFeaturedProductDto updateFeaturedProductDto)
        {
            if (updateFeaturedProductDto == null)
                throw new ArgumentNullException(nameof(updateFeaturedProductDto));

            try
            {
                await _httpClient.PutAsJsonAsync<UpdateFeaturedProductDto>("features", updateFeaturedProductDto);
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateFeaturedProductAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }
    }
}
