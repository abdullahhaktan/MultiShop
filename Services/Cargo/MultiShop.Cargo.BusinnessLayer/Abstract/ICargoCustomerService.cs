using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinnessLayer.Abstract
{
    public interface ICargoCustomerService : IGenericService<CargoCustomer>
    {
        Task<CargoCustomer> TGetCargoCustomerById(string id);
    }
}
