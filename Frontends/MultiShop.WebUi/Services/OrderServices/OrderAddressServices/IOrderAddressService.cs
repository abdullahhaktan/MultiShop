using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUi.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressService
    {
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
    }
}
