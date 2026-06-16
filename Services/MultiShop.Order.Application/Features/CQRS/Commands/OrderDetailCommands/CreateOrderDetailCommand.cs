namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class CreateOrderDetailCommand
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductTotalPrice { get; set; }

        public int OrderingId { get; set; }
    }
}
