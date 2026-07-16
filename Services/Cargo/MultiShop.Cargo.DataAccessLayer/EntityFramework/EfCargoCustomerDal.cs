using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _cargoContext;
        public EfCargoCustomerDal(CargoContext cargoContext) : base(cargoContext)
        {
            _cargoContext = cargoContext;
        }

        public async Task<CargoCustomer> GetCargoCustomerByIdAsync(string id)
        {
            var values = await _cargoContext.CargoCustomers.Where(cc => cc.UserCustomerId == id).FirstOrDefaultAsync();
            return values;
        }
    }
}
