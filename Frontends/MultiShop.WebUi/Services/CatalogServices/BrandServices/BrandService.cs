using MultiShop.DtoLayer.BrandDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.CatalogServices.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _httpClient;
        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            if (createBrandDto == null)
                throw new ArgumentNullException(nameof(createBrandDto));

            try
            {
                await _httpClient.PostAsJsonAsync<CreateBrandDto>("brands", createBrandDto);
            }
            catch (Exception ex)
            {
                throw new Exception("CreateBrandAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task DeleteBrandAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                await _httpClient.DeleteAsync($"brands/{id}");
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteBrandAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            try
            {
                var responseMessage = await _httpClient.GetAsync("brands");
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(jsonData))
                    return new List<ResultBrandDto>();

                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return values;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllBrandAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<GetBrandByIdDto> GetBrandByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                var responseMessage = await _httpClient.GetAsync("brands/" + id);
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var value = await responseMessage.Content.ReadFromJsonAsync<GetBrandByIdDto>();
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception("GetBrandByIdAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            if (updateBrandDto == null)
                throw new ArgumentNullException(nameof(updateBrandDto));

            try
            {
                await _httpClient.PutAsJsonAsync<UpdateBrandDto>("brands", updateBrandDto);
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateBrandAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }
    }
}
