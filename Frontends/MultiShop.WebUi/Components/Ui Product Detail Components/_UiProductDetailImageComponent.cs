using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.ProductDetailDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Components.Ui_Product_Detail_Components
{
    public class _UiProductDetailImageComponent(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            // 1. productId boşsa hiç API'yi yorma
            if (string.IsNullOrEmpty(productId))
            {
                return View(new GetProductImageByIdDto()); // Boş bir nesne dön ki Model null referans vermesin
            }

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/ProductImages/GetProductImageIdByProductId/{productId}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var id = await responseMessage.Content.ReadAsStringAsync();

                var responseMessage1 = await client.GetAsync($"https://localhost:7070/api/ProductImages/{id}");
                if (responseMessage1.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage1.Content.ReadAsStringAsync();
                    var value1 = JsonConvert.DeserializeObject<GetProductImageByIdDto>(jsonData);
                    return View(value1);
                }
            }

            return View(new GetProductImageByIdDto());
        }
    }
}
