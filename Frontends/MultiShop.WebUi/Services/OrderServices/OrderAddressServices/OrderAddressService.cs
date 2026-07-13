using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUi.Services.OrderServices.OrderAddressServices
{
    public class OrderAddressService : IOrderAddressService
    {
        private readonly HttpClient _httpClient;

        public OrderAddressService(HttpClient httpClient)
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