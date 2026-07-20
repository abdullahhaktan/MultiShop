
namespace MultiShop.WebUi.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<long> GetBrandCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Statistics/GetBrandCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }

        public async Task<long> GetCategoryCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Statistics/GetCategoryCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }

        public async Task<string> GetMaxPriceProductNameAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Statistics/GetMaxPriceProductName");
            var values = await responseMessage.Content.ReadAsStringAsync();
            return values;
        }

        public async Task<string> GetMinPriceProductNameAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Statistics/GetMinPriceProductName");
            var values = await responseMessage.Content.ReadAsStringAsync();
            return values;
        }

        public async Task<decimal> GetProductAvgPriceAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Statistics/GetProductAvgPrice");
            var values = await responseMessage.Content.ReadFromJsonAsync<decimal>();
            return values;
        }

        public async Task<long> GetProductCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Statistics/GetProductCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }
    }
}
