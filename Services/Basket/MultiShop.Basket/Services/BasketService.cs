using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            var basket = await _redisService.GetDb().StringGetAsync(userId);

            // Eğer Redis'te veri yoksa null döndürülüyor
            if (basket.IsNull)
            {
                return new BasketTotalDto
                {
                    UserId = userId,
                    BasketItems = new List<BasketItemDto>()
                };
            }

            try
            {
                var deserializedBasket = JsonSerializer.Deserialize<BasketTotalDto>(basket.ToString());
                return deserializedBasket ?? new BasketTotalDto
                {
                    UserId = userId,
                    BasketItems = new List<BasketItemDto>()
                };
            }

            catch (JsonException)
            {
                return new BasketTotalDto
                {
                    UserId = userId,
                    BasketItems = new List<BasketItemDto>()
                };
            }
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            Console.WriteLine("========== REDIS SAVE ==========");

            if (basketTotalDto == null)
            {
                Console.WriteLine("basketTotalDto NULL");
                return;
            }

            Console.WriteLine($"UserId: {basketTotalDto.UserId}");

            var json = JsonSerializer.Serialize(basketTotalDto);

            Console.WriteLine($"Json: {json}");

            var result = await _redisService.GetDb().StringSetAsync(
                basketTotalDto.UserId,
                json
            );

            Console.WriteLine($"Redis Save Result: {result}");

            var savedValue = await _redisService.GetDb().StringGetAsync(basketTotalDto.UserId);

            Console.WriteLine($"Redis Read After Save: {savedValue}");

            Console.WriteLine("================================");
        }
    }
}