using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUi.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<GetDisountCodeDetailByCode> GetDiscounCode(string code);
        Task<int> GetDiscountCouponCountRate(string code);
    }
}
