namespace MultiShop.WebUi.Services.StatisticServices.CommentService
{
    public class UserCommentStatisticService : IUserCommentStatisticService
    {
        private readonly HttpClient _httpClient;

        public UserCommentStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetActiveCommentCountASync()
        {
            var responseMessage = await _httpClient.GetAsync("userComments/GetActiveCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<int> GetPassiveCommentCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("userComments/GetPassiveCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<int> GetTotalCommentCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("userComments/GetTotalCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
