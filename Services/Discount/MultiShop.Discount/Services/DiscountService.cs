using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountAsync(CreateDiscountDto createCouponDto)
        {
            var query = "insert into Discounts (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";

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

        public async Task DeleteDiscountAsync(int couponId)
        {
            string query = "Delete From Discounts Where DiscountId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", couponId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountDto>> GetAllDiscountAsync()
        {
            string query = "Select * From Discounts";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountDto>(query);

                return values.ToList();
            }
        }

        public async Task<GetDiscountByIdDto> GetDiscountByIdAsync(int discountDiscountId)
        {
            string query = "Select * From Discounts Where DiscountId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", discountDiscountId);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetDiscountByIdDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateDiscountAsync(UpdateDiscountDto updateDiscountDto)
        {
            var query = "Update Discounts set Code=@code , Rate=@rate, IsActive=@isActive, ValidDate=@validDate Where DiscountId=@couponId";

            var parameters = new DynamicParameters();
            parameters.Add("@couponId", updateDiscountDto.DiscountId);
            parameters.Add("@code", updateDiscountDto.Code);
            parameters.Add("@rate", updateDiscountDto.Rate);
            parameters.Add("@isActive", updateDiscountDto.IsActive);
            parameters.Add("@validDate", updateDiscountDto.ValidDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
