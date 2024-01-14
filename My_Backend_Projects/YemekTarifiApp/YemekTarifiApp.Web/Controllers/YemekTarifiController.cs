//using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using System.Net.NetworkInformation;
using YemekTarifiApp.Business.Abstract;
using YemekTarifiApp.Entity.Concrate;
using YemekTarifiApp.Web.Areas.Admin.Models.Dtos;
using YemekTarifiApp.Web.Models.Dtos;

namespace YemekTarifiApp.Web.Controllers
{
	public class YemekTarifiController : Controller
	{
		private readonly IFoodService _foodManager;
		public YemekTarifiController(IFoodService foodManager)
		{
			_foodManager = foodManager;
		}
		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> FoodList(string categoryurl)
		{
			List<Food> foods = await _foodManager.GetFoodsByCategoryAsync(categoryurl);
			List<FoodDto> foodDtos = new List<FoodDto>();
			foreach (var food in foods)
			{
				foodDtos.Add(new FoodDto
				{
					Id = food.Id,
					Name = food.Name,
					Material = food.Material,
					ImageUrl = food.ImageUrl,
					Url = food.Url,
				});
			}
			return View(foodDtos);
		}
		public async Task<IActionResult> FoodDetails(string foodurl)
		{
			if (foodurl == null)
			{
				return NotFound();
			}
			var food = await _foodManager.GetFoodDetailsByUrlAsync(foodurl);
			FoodDetailsDto foodDetailsDto = new FoodDetailsDto
			{
				Id = food.Id,
				Name = food.Name,
				Material = food.Material,
				Description = food.Description,
				Url = food.Url,
				ImageUrl = food.ImageUrl,
				Point = food.Point,

				Recipes = food.FoodRecipes
				.Select(fr => fr.Recipe)
				.ToList(),

				Comments = food.Comments
				.ToList(),

				Categories = food
				 .FoodCategories
				 .Select(fc => fc.Category)
				 .ToList()
			};
			return View(foodDetailsDto);

		}

		public IActionResult CommentCreate()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CommentCreate(Comment comment)
		{
			if (ModelState.IsValid)
			{
				comment.Confirmation = true;
				comment.DateAdded = DateTime.Now;
				await _foodManager.CreateCommentAsync(comment);
			};
			return RedirectToAction("CommentCreate");
			//return View();
		}

		
	}
}
