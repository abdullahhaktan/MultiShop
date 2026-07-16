using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.CargoServices.CargoCompanyServices
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly HttpClient _httpClient;
        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
        {
            if (createCargoCompanyDto == null)
            {
                throw new ArgumentNullException(nameof(createCargoCompanyDto));
            }

            var response = await _httpClient.PostAsJsonAsync<CreateCargoCompanyDto>("CargoCompanies", createCargoCompanyDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
            }
        }

        public async Task DeleteCargoCompanyAsync(int id)
        {
            if (id <= 0)
            {
                return;
            }

            var responseMessage = await _httpClient.DeleteAsync($"CargoCompanies/{id}");


            if (!responseMessage.IsSuccessStatusCode)
            {
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
            }

        }

        public async Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyAsync()
        {
            var responseMessage = await _httpClient.GetAsync("CargoCompanies");

            // İstek başarısızsa veya response null ise direkt boş liste dönerek çökmesini engelliyoruz
            if (responseMessage == null || !responseMessage.IsSuccessStatusCode)
            {
                return new List<ResultCargoCompanyDto>();
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(jsonData))
            {
                return new List<ResultCargoCompanyDto>();
            }

            var values = JsonConvert.DeserializeObject<List<ResultCargoCompanyDto>>(jsonData);
            return values ?? new List<ResultCargoCompanyDto>();
        }

        public async Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            var responseMessage = await _httpClient.GetAsync($"CargoCompanies/{id}");
            if (responseMessage == null || !responseMessage.IsSuccessStatusCode)
            {
                return null;
            }

            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCargoCompanyDto>();
            return values;
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            if (updateCargoCompanyDto == null)
            {
                throw new ArgumentNullException(nameof(updateCargoCompanyDto));
            }
            await _httpClient.PutAsJsonAsync<UpdateCargoCompanyDto>("CargoCompanies", updateCargoCompanyDto);
        }
    }
}