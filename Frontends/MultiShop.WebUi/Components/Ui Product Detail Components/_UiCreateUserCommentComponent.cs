using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.UserCommentDtos;

namespace MultiShop.WebUi.Components.Ui_Product_Detail_Components
{
    public class _UiCreateUserCommentComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            CreateUserCommentDto createUserCommentDto = new CreateUserCommentDto();
            return View(createUserCommentDto);
        }
    }
}
