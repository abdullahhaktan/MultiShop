using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.AboutDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Components.Ui_Layout_Components
{
    public class _UiLayoutFooterAboutComponent(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Abouts");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetAboutByIdDto>(jsonData);
                return View(value);
            }

            return View();
        }
    }
}
