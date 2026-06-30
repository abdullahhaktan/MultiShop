using MultiShop.DtoLayer.AboutDtos;

namespace MultiShop.WebUi.Services.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;
        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            if (createAboutDto == null)
                throw new ArgumentNullException(nameof(createAboutDto));

            try
            {
                await _httpClient.PostAsJsonAsync<CreateAboutDto>("abouts", createAboutDto);
            }
            catch (Exception ex)
            {
                throw new Exception("CreateAboutAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task DeleteAboutAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                await _httpClient.DeleteAsync($"abouts/{id}");
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteAboutAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<GetAboutByIdDto> GetAboutByIdAsync()
        {
            try
            {
                var responseMessage = await _httpClient.GetAsync("abouts");
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var value = await responseMessage.Content.ReadFromJsonAsync<GetAboutByIdDto>();
                if (value == null)
                    throw new Exception("API'den boş yanıt döndü.");

                return value;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAboutByIdAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            if (updateAboutDto == null)
                throw new ArgumentNullException(nameof(updateAboutDto));

            try
            {
                await _httpClient.PutAsJsonAsync<UpdateAboutDto>("abouts", updateAboutDto);
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateAboutAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }
    }
}
