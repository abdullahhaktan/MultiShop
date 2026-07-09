using MultiShop.DtoLayer.OrderDtos.Order_Address_Dtos;

namespace MultiShop.WebUi.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto)
        {
            var response = await _httpClient.PostAsJsonAsync("addresses", createOrderAddressDto);
            response.EnsureSuccessStatusCode();
        }
    }
}