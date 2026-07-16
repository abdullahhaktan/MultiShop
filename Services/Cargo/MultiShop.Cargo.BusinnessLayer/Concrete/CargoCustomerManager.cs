using MultiShop.Cargo.BusinnessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinnessLayer.Concrete
{
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomerDal;

        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
        {
            _cargoCustomerDal = cargoCustomerDal;
        }

        public async Task TDeleteAsync(int id)
        {
            await _cargoCustomerDal.Delete(id);
        }

        public async Task<List<CargoCustomer>> TGetAllAsync()
        {
            var values = await _cargoCustomerDal.GetAll();
            return values;
        }

        public async Task<CargoCustomer> TGetByIdAsync(int id)
        {
            var value = await _cargoCustomerDal.GetById(id);
            return value;
        }

        public async Task<CargoCustomer> TGetCargoCustomerById(string id)
        {
            return await _cargoCustomerDal.GetCargoCustomerByIdAsync(id);
        }

        public async Task TInsertAsync(CargoCustomer cargoCustomer)
        {
            await _cargoCustomerDal.Insert(cargoCustomer);
        }

        public async Task TUpdateAsync(CargoCustomer cargoCustomer)
        {
            await _cargoCustomerDal.Update(cargoCustomer);
        }
    }
}
