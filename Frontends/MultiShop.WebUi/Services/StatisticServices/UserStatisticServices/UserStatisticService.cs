using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.StatisticServices.UserStatisticServices
{
    public class UserStatisticService : IUserStatisticService
    {
        private readonly HttpClient _httpClient;

        public UserStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetUserCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5001/api/Statistics");
            if (responseMessage == null || !responseMessage.IsSuccessStatusCode)
                return 0;
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(jsonData))
                return 0;
            var values = JsonConvert.DeserializeObject<int>(jsonData);
            return values;
        }
    }
}