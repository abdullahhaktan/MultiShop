using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUi.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id);
    }
}
