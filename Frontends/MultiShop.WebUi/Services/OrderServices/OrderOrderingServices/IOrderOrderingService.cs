using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace MultiShop.WebUi.Services.OrderServices.OrderingServices
{
    public interface IOrderOrderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
    }
}
