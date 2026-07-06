using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.CatalogServices.CategoryServices;

namespace MultiShop.WebUi.Components.Ui_Default_Components
{
    public class _UiDefaultCategoryComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _UiDefaultCategoryComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();

            return View(values);
        }
    }
}
