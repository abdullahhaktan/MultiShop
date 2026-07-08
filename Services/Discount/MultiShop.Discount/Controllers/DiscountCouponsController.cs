using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCouponsController : ControllerBase
    {
        private readonly IDiscountCouponService _discountCouponService;

        public DiscountCouponsController(IDiscountCouponService discountCouponService)
        {
            _discountCouponService = discountCouponService;
        }

        [HttpGet]
        public async Task<IActionResult> CuponList()
        {
            var values = await _discountCouponService.GetAllDiscountCouponAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountById(int id)
        {
            var value = await _discountCouponService.GetDiscountCouponByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("GetDiscountCouponCountRate/{couponCode}")]
        public  IActionResult GetCodeDetailByCode(string couponCode)
        {
            var value = _discountCouponService.GetDiscountCouponCountRate(couponCode);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountCouponDto createCuponDto)
        {
            await _discountCouponService.CreateDiscountCouponAsync(createCuponDto);
            return Ok("Kupon başarıyla oluşturuldu");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            await _discountCouponService.DeleteDiscountCouponAsync(id);
            return Ok("Kupon başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            await _discountCouponService.UpdateDiscountCouponAsync(updateDiscountCouponDto);
            return Ok("Kupon başarıyla güncellendi");
        }
    }
}
