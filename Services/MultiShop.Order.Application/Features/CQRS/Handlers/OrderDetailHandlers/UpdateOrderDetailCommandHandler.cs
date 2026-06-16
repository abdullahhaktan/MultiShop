using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var value = await _repository.GetByIdAsync(command.OrderDetailId);

            value.Id = command.Id;
            value.ProductName = command.ProductName;
            value.Price = command.Price;
            value.ProductAmount = command.ProductAmount;
            value.ProductTotalPrice = command.ProductTotalPrice;
            value.OrderingId = command.OrderingId;

            await _repository.UpdateAsync(value);
        }
    }
}
