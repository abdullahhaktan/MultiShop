using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUi.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var value = await GetBasket();

            if (value != null && value.BasketItems != null)
            {
                if (!value.BasketItems.Any(bi => bi.ProductId == basketItemDto.ProductId))
                {
                    value.BasketItems.Add(basketItemDto);
                }
                else
                {
                    var basketItem = value.BasketItems.Where(bi => bi.ProductId == basketItemDto.ProductId).FirstOrDefault();

                    basketItem.Quantity += basketItemDto.Quantity;
                }
            }
            else
            {
                value = new BasketTotalDto { BasketItems = new List<BasketItemDto>() };
                value.BasketItems.Add(basketItemDto);
            }

            await SaveBasket(value);
        }

        public Task DeleteBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketTotalDto> GetBasket()
        {
            try
            {
                var responseMessage = await _httpClient.GetAsync("baskets");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();

                    if (values != null && values.BasketItems == null)
                    {
                        values.BasketItems = new List<BasketItemDto>();
                    }

                    return values ?? new BasketTotalDto { BasketItems = new List<BasketItemDto>() };
                }

                return new BasketTotalDto { BasketItems = new List<BasketItemDto>() };
            }
            catch (Exception)
            {
                return new BasketTotalDto { BasketItems = new List<BasketItemDto>() };
            }
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var values = await GetBasket();

            if (values == null || values.BasketItems == null || !values.BasketItems.Any())
                return false;

            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);

            if (deletedItem == null)
                return false;

            var result = values.BasketItems.Remove(deletedItem);

            if (result)
            {
                await SaveBasket(values);
            }

            return result;
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            Console.WriteLine("========== WEBUI SAVE BASKET ==========");

            if (basketTotalDto == null)
            {
                Console.WriteLine("basketTotalDto NULL");
                return;
            }

            Console.WriteLine($"UserId: {basketTotalDto.UserId}");
            Console.WriteLine($"Item Count: {basketTotalDto.BasketItems?.Count}");

            var response = await _httpClient.PostAsJsonAsync("baskets", basketTotalDto);

            Console.WriteLine($"Status Code: {response.StatusCode}");

            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Response Content: {content}");

            Console.WriteLine("=======================================");
        }
    }
}