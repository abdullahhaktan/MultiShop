using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountCouponService
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync();
        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto);
        Task DeleteDiscountCouponAsync(int couponId);
        Task<GetDiscountCouponByIdDto> GetDiscountCouponByIdAsync(int discountDiscountId);
        int GetDiscountCouponCountRate(string couponCode);
        //Task<int> GetDiscountCouponCount();
    }
}
