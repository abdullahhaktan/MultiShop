using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUi.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDisountCodeDetailByCode> GetDiscounCode(string couponCode)
        {
            var responseMessage = await _httpClient.GetAsync($"discountCoupons/GetDiscountCodeDetailByCode/{couponCode}");
            var values = await responseMessage.Content.ReadFromJsonAsync<GetDisountCodeDetailByCode>();
            return values;
        }

        public async Task<int> GetDiscountCouponCountRate(string couponCode)
        {
            var responseMessage = await _httpClient.GetAsync($"http://localhost:7071/api/DiscountCoupons/GetDiscountCouponCountRate/{couponCode}");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
