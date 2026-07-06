using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.CatalogServices.CategoryServices;

namespace MultiShop.WebUi.Components.Ui_Layout_Components
{
    public class _UiLayoutNavbarComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _UiLayoutNavbarComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetAllCategoryAsync();

            return View(categories);
        }
    }
}
