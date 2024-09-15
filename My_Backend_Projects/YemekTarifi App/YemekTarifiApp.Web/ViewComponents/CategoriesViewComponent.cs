using Microsoft.AspNetCore.Mvc;
using YemekTarifiApp.Business.Abstract;

namespace YemekTarifiApp.Web.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        private readonly ICategoryService _categoryManager;

        public CategoriesViewComponent(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (RouteData.Values["categoryurl"] != null)
            {
                ViewBag.SelectedCategory = RouteData.Values["categoryurl"];
            }
            var categories = await _categoryManager.GetAllAsync();
            return View(categories);
        }
    }
}
