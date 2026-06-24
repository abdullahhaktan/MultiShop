using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                ProductAmount = createOrderDetailCommand.ProductAmount,
                Id = createOrderDetailCommand.Id,
                ProductName = createOrderDetailCommand.ProductName,
                Price = createOrderDetailCommand.Price,
                ProductTotalPrice = createOrderDetailCommand.ProductTotalPrice,
                OrderingId = createOrderDetailCommand.OrderingId
            });
        }
    }
}
