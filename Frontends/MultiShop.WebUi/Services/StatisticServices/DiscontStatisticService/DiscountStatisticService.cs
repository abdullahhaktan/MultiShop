
namespace MultiShop.WebUi.Services.StatisticServices.DiscontStatisticService
{
    public class DiscountStatisticService : IDiscountStatisticService
    {
        private readonly HttpClient _httpClient;
        public DiscountStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetDiscountCouponCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("DiscountCoupons/GetDiscountCouponCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
