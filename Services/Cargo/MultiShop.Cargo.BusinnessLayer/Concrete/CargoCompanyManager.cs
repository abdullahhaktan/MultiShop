using MultiShop.Cargo.BusinnessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinnessLayer.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;

        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
        {
            _cargoCompanyDal = cargoCompanyDal;
        }

        public async Task TDeleteAsync(int id)
        {
            await _cargoCompanyDal.Delete(id);
        }

        public async Task<List<CargoCompany>> TGetAllAsync()
        {
            var values = await _cargoCompanyDal.GetAll();
            return values;
        }

        public async Task<CargoCompany> TGetByIdAsync(int id)
        {
            var value = await _cargoCompanyDal.GetById(id);
            return value;
        }

        public async Task TInsertAsync(CargoCompany entity)
        {
            await _cargoCompanyDal.Insert(entity);
        }

        public async Task TUpdateAsync(CargoCompany entity)
        {
            await _cargoCompanyDal.Update(entity);
        }
    }
}
