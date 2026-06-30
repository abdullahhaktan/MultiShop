
using MultiShop.DtoLayer.FeatureSliderDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.Catalog_Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;
        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            if (createFeatureSliderDto == null)
                throw new ArgumentNullException(nameof(createFeatureSliderDto));

            try
            {
                await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("featureSliders", createFeatureSliderDto);
            }
            catch (Exception ex)
            {
                throw new Exception("CreateFeatureSliderAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                await _httpClient.DeleteAsync($"featureSliders/{id}");
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteFeatureSliderAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            try
            {
                var responseMessage = await _httpClient.GetAsync("featureSliders");
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(jsonData))
                    return new List<ResultFeatureSliderDto>();

                var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
                return values;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllFeatureSliderAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<GetFeatureSliderByIdDto> GetFeatureSliderByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                var responseMessage = await _httpClient.GetAsync("featureSliders/" + id);
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var value = await responseMessage.Content.ReadFromJsonAsync<GetFeatureSliderByIdDto>();
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception("GetFeatureSliderByIdAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            if (updateFeatureSliderDto == null)
                throw new ArgumentNullException(nameof(updateFeatureSliderDto));

            try
            {
                await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("featureSliders", updateFeatureSliderDto);
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateFeatureSliderAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }
    }
}
