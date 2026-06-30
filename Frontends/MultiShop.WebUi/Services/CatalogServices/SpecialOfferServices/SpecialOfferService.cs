using MultiShop.DtoLayer.SpecialOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.Catalog_Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;
        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            if (createSpecialOfferDto == null)
                throw new ArgumentNullException(nameof(createSpecialOfferDto));

            try
            {
                await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("specialOffers", createSpecialOfferDto);
            }
            catch (Exception ex)
            {
                throw new Exception("CreateSpecialOfferAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                await _httpClient.DeleteAsync($"specialOffers/{id}");
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteSpecialOfferAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            try
            {
                var responseMessage = await _httpClient.GetAsync("specialOffers");
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(jsonData))
                    return new List<ResultSpecialOfferDto>();

                var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
                return values;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllSpecialOfferAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task<GetSpecialOfferByIdDto> GetSpecialOfferByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            try
            {
                var responseMessage = await _httpClient.GetAsync("specialOffers/" + id);
                if (responseMessage == null)
                    throw new Exception("API'den yanıt alınamadı.");

                var value = await responseMessage.Content.ReadFromJsonAsync<GetSpecialOfferByIdDto>();
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception("GetSpecialOfferByIdAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            if (updateSpecialOfferDto == null)
                throw new ArgumentNullException(nameof(updateSpecialOfferDto));

            try
            {
                await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("specialOffers", updateSpecialOfferDto);
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateSpecialOfferAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }
    }
}