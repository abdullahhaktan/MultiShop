using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using MultiShop.Order.Persistence.Context;

namespace MultiShop.Order.Persistence.Repositories
{
    public class OrderingRepository : IOrderingRepository
    {
        private readonly OrderContext _orderContext;

        public OrderingRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public async Task<List<Ordering>> GetOrderingsByUserId(string id)
        {
            var values = await _orderContext.Orderings.Where(x => x.UserId == id).ToListAsync();
            return values;
        }
    }
}
