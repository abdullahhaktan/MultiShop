using MultiShop.DtoLayer.OrderDtos.Order_Address_Dtos;

namespace MultiShop.WebUi.Services.OrderServices
{
    public interface IOrderService
    {
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
    }
}
