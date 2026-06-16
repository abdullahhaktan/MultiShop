using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BrandDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Components.Ui_Default_Components
{
    public class _UiDefaultBrandComponent(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Brands");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
