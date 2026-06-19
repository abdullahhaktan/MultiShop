using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.ProductDtos;
using MultiShop.DtoLayer.UserCommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Components.Ui_Product_Detail_Components
{
    public class _UiUserCommentComponent(IHttpClientFactory _httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7095/api/UserComments/GetUserCommentsByProductId/{productId}");

            string id = productId;

            var responseMessage1 = await client.GetAsync($"https://localhost:7070/api/Products/{id}");

            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage1.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetProductByIdDto>(jsonData);
                if (value != null)
                {
                    ViewBag.Product = value.ProductName;
                }
                else
                {
                    ViewBag.Product = "Ürün bulunamadı";
                }
            }

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultUserCommentDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
