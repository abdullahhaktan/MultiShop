using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountCouponService : IDiscountCouponService
    {
        private readonly DapperContext _context;

        public DiscountCouponService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            var query = "insert into DiscountCoupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";

            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int couponId)
        {
            string query = "Delete From DiscountCoupons Where DiscountId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", couponId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "Select * From DiscountCoupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);

                return values.ToList();
            }
        }

        public async Task<ResultDiscountCouponDto> GetDiscountCodeDetailByCodeAsync(string code)
        {
            string query = "Select * From DiscountCoupons where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultDiscountCouponDto>(query, parameters);
                return values;
            }
        }

        public async Task<GetDiscountCouponByIdDto> GetDiscountCouponByIdAsync(int discountDiscountId)
        {
            string query = "Select * From DiscountCoupons Where DiscountId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", discountDiscountId);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetDiscountCouponByIdDto>(query, parameters);
                return values;
            }
        }

        public async Task<int> GetDiscountCouponCount()
        {
            string query = "Select Count(*) From DiscountCoupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }

        }

        public int GetDiscountCouponCountRate(string couponCode)
        {
            string query = "Select Rate From DiscountCoupons Where Code=@couponCode";
            var parameters = new DynamicParameters();
            parameters.Add("@couponCode", couponCode);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            var query = "Update DiscountCoupons set Code=@code , Rate=@rate, IsActive=@isActive, ValidDate=@validDate Where DiscountId=@couponId";

            var parameters = new DynamicParameters();
            parameters.Add("@couponId", updateDiscountCouponDto.DiscountId);
            parameters.Add("@code", updateDiscountCouponDto.Code);
            parameters.Add("@rate", updateDiscountCouponDto.Rate);
            parameters.Add("@isActive", updateDiscountCouponDto.IsActive);
            parameters.Add("@validDate", updateDiscountCouponDto.ValidDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
