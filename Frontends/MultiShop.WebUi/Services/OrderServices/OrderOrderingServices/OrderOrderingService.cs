using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MultiShop.WebUi.Services.OrderServices.OrderingServices
{
    public class OrderOrderingService : IOrderOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderOrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return new List<ResultOrderingByUserIdDto>();
                }

                var responseMessage = await _httpClient.GetAsync($"orderings/GetOrderingByUserId/{id}");

                if (!responseMessage.IsSuccessStatusCode)
                {
                    return new List<ResultOrderingByUserIdDto>();
                }

                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(jsonData))
                {
                    return new List<ResultOrderingByUserIdDto>();
                }

                var values = JsonConvert.DeserializeObject<List<ResultOrderingByUserIdDto>>(jsonData);

                return values ?? new List<ResultOrderingByUserIdDto>();
            }
            catch (HttpRequestException)
            {
                return new List<ResultOrderingByUserIdDto>();
            }
            catch (JsonException)
            {
                return new List<ResultOrderingByUserIdDto>();
            }
            catch (Exception)
            {
                return new List<ResultOrderingByUserIdDto>();
            }
        }
    }
}