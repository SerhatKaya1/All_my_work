using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YemekTarifiApp.Business.Abstract;
using YemekTarifiApp.Entity.Concrate;
using YemekTarifiApp.Web.Areas.Admin.Models.Dtos;
using YemekTarifiApp.Web.Models;
using YemekTarifiApp.Web.Models.Dtos;

namespace YemekTarifiApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFoodService _foodManager;

        public HomeController(IFoodService foodManager)
        {
            _foodManager = foodManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Food> foods = await _foodManager.GetHomePageFoodsAsync();
            List<FoodDto> foodDtos = new List<FoodDto>();
            foreach (var food in foods)
            {
                foodDtos.Add(new FoodDto
                {
                    Id= food.Id,
                    Name=food.Name,
                    Material=food.Material,
                    ImageUrl = food.ImageUrl,
                    Url = food.Url,
                });
            }
            return View(foodDtos);
            
        }
        public async Task<IActionResult> Search(SearchQueryDto searchQueryDto)
        {
            List<Food> searchResults = await _foodManager.GetSearchResultsAsync(p => p.IsApproved);
            List<FoodDto> foodDtos = new List<FoodDto>();
            foreach (var food in searchResults)
            {
                foodDtos.Add(new FoodDto
                {
                    Id = food.Id,
                    Name = food.Name,
                    Material = food.Material,
                    ImageUrl = food.ImageUrl,
                    Url = food.Url
                });
            }
            return View(foodDtos);
        }
    }
}