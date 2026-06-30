using MultiShop.DtoLayer.FeatureDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.CatalogServices.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;
        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            if (createFeatureDto == null)
                throw new ArgumentNullException(nameof(createFeatureDto));

            try
            {
                await _httpClient.PostAsJsonAsync<CreateFeatureDto>("features", createFeatureDto);
            }
            catch (Exception ex)
            {
                throw new Exception("CreateFeatureAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task DeleteFeatureAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                await _httpClient.DeleteAsync($"features/{id}");
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteFeatureAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            try
            {
                var responseMessage = await _httpClient.GetAsync("features");
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(jsonData))
                    return new List<ResultFeatureDto>();

                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return values;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllFeatureAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<GetFeatureByIdDto> GetFeatureByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                var responseMessage = await _httpClient.GetAsync("features/" + id);
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var value = await responseMessage.Content.ReadFromJsonAsync<GetFeatureByIdDto>();
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception("GetFeatureByIdAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            if (updateFeatureDto == null)
                throw new ArgumentNullException(nameof(updateFeatureDto));

            try
            {
                await _httpClient.PutAsJsonAsync<UpdateFeatureDto>("features", updateFeatureDto);
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateFeatureAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }
    }
}
