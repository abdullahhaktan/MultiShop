using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.ProductDetailDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Components.Ui_Product_Detail_Components
{
    public class _UiProductDetailDescriptionComponent(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/ProductDetails/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonData);
                return View(value);
            }

            return View();
        }
    }
}
