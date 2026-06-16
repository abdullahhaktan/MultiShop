using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Components.Ui_Product_Components
{
    public class _UiProductListComponent(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = new HttpResponseMessage();

            if (categoryId != null)
            {
                responseMessage = await client.GetAsync($"https://localhost:7070/api/Products/GetByCategory/{categoryId}");

            }
            else
            {
                responseMessage = await client.GetAsync($"https://localhost:7070/api/Products");
            }


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
