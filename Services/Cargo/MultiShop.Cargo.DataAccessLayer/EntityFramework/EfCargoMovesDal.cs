using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoMovesDal : GenericRepository<CargoMoves>, ICargoMovesDal
    {
        public EfCargoMovesDal(CargoContext context) : base(context)
        {
        }
    }
}
