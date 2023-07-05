using Microsoft.AspNetCore.Mvc;
using YemekTarifiApp.Business.Abstract;
using YemekTarifiApp.Core;
using YemekTarifiApp.Entity.Concrate;
using YemekTarifiApp.Entity.Concrate.Identity;
using YemekTarifiApp.Web.Areas.Admin.Models.Dtos;
namespace YemekTarifiApp.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class FoodController : Controller
	{
		private readonly IFoodService _foodService;
		private readonly ICategoryService _categoryService;

		public FoodController(IFoodService foodService, ICategoryService categoryService)
		{
			_foodService = foodService;
			_categoryService = categoryService;
		}
		public async Task<IActionResult> Index()
		{
			var foods = await _foodService.GetFoodsWithCategories();
			var foodListDto = foods
				.Select(p => new FoodListDto
				{

					Food = p

				}).ToList();

			return View(foodListDto);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var categories = await _categoryService.GetAllAsync();
			var foodAddDto = new FoodAddDto
			{
				Categories = categories
			};
			return View(foodAddDto);
		}

		[HttpPost]
		public async Task<IActionResult> Create(FoodAddDto foodAddDto)
		{
			if (ModelState.IsValid)
			{
				var url = Jobs.InitUrl(foodAddDto.Name);
				
				var food = new Food
				{
					Name = foodAddDto.Name,
					Material = foodAddDto.Material,
					Description = foodAddDto.Description,
					Url = url,
					IsApproved = foodAddDto.IsApproved,
					IsHome = foodAddDto.IsHome,
					ImageUrl = Jobs.UploadImage(foodAddDto.ImageFile),

				};
				await _foodService.CreateFoodAsync(food, foodAddDto.SelectedCategoryIds, foodAddDto.RecipeMaking);
				return RedirectToAction("Index");
			}
			var categories = await _categoryService.GetAllAsync();
			foodAddDto.Categories = categories;
			foodAddDto.ImageUrl = foodAddDto.ImageUrl;
			return View(foodAddDto);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{

			var food = await _foodService.GetFoodWithCategories(id);
			FoodUpdateDto productUpdateDto = new FoodUpdateDto
			{
				Id = food.Id,
				Name = food.Name,
				Material = food.Material,
				Description = food.Description,
				//RecipeMaking = food.RecipeMaking,
				IsApproved = food.IsApproved,
				IsHome = food.IsHome,
				ImageUrl = food.ImageUrl,
				Categories = await _categoryService.GetAllAsync(),
				SelectedCategoryIds = food.FoodCategories.Select(pc => pc.CategoryId).ToArray()
			};
			return View(productUpdateDto);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(FoodUpdateDto foodUpdateDto, int[] selectedCategoryIds)
		{
			if (ModelState.IsValid)
			{
				var food = await _foodService.GetByIdAsync(foodUpdateDto.Id);
				if (food == null)
				{
					return NotFound();
				}
				var url = Jobs.InitUrl(foodUpdateDto.Name);
				food.Name = foodUpdateDto.Name;
				food.Material = foodUpdateDto.Material;
				food.Description = foodUpdateDto.Description;
				//food.RecipeMaking = foodUpdateDto.RecipeMaking;
				food.IsApproved = foodUpdateDto.IsApproved;
				food.IsHome = foodUpdateDto.IsHome;
				food.ImageUrl = Jobs.UploadImage(foodUpdateDto.ImageFile);
				food.Url = url;
				await _foodService.UpdateFoodAsync(food, selectedCategoryIds);
				return RedirectToAction("Index");
			}
			var categories = await _categoryService.GetAllAsync();
			foodUpdateDto.Categories = categories;

			return View(foodUpdateDto);
		}
		public async Task<IActionResult> UpdateIsHome(int id)
		{
			var food = await _foodService.GetByIdAsync(id);
			if (food == null) { return NotFound(); }
			await _foodService.UpdateIsHomeAsync(food);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> UpdateIsApproved(int id)
		{
			var food = await _foodService.GetByIdAsync(id);
			if (food == null) { return NotFound(); }
			await _foodService.UpdateIsApprovedAsync(food);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Delete(int id)
		{
			var food = await _foodService.GetByIdAsync(id);
			if (food == null) { return NotFound(); }
			_foodService.Delete(food);
			return RedirectToAction("Index");
		}
	}
}
