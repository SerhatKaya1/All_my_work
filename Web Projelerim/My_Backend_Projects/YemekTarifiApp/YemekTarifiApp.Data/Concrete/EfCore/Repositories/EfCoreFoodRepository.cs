using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YemekTarifiApp.Data.Abstract;
using YemekTarifiApp.Data.Concrete.EfCore.Contexts;
using YemekTarifiApp.Entity.Concrate;

namespace YemekTarifiApp.Data.Concrete.EfCore.Repositories
{
	public class EfCoreFoodRepository : EfCoreGenericRepository<Food>, IFoodRepository
	{
		public EfCoreFoodRepository(DbContext context) : base(context)
		{

		}
		private YemekTarifiAppContext YemekTarifiAppContext
		{
			get { return _context as YemekTarifiAppContext; }
		}

		public async Task<List<Food>> GetHomePageFoodsAsync()
		{
			return await YemekTarifiAppContext
				 .Foods
				 .Where(p => p.IsHome && p.IsApproved)
				 .ToListAsync();
		}

		public Task<Food> GetFoodDetailsByUrlAsync(string foodUrl)
		{
			return YemekTarifiAppContext
				.Foods
				.Where(p => p.Url == foodUrl)
				.Include(p => p.FoodCategories)
				.ThenInclude(pc => pc.Category)
				.Include(p => p.FoodRecipes)
				.ThenInclude(fr => fr.Recipe)
				.Include(p => p.Comments)
				.FirstOrDefaultAsync();
		}

		public async Task<List<Food>> GetFoodsByCategoryAsync(string category)
		{
			var foods = YemekTarifiAppContext.Foods.AsQueryable();
			if (category != null)
			{
				foods = foods
					.Where(p => p.IsApproved)
					.Include(p => p.FoodCategories)
					.ThenInclude(pc => pc.Category)
					.Where(p => p.FoodCategories.Any(pc => pc.Category.Url == category));
			}
			return await foods.ToListAsync();
		}


		public async Task<List<Food>> GetFoodsWithCategories()
		{
			return await YemekTarifiAppContext
				.Foods
				.Include(f => f.FoodCategories)
				.ThenInclude(fc => fc.Category)
				.Include(f => f.FoodRecipes)
				.ThenInclude(fc => fc.Recipe)
				.ToListAsync();
		}

		public async Task<Food> GetFoodWithCategories(int id)
		{
			return await YemekTarifiAppContext
			   .Foods
			   .Where(p => p.Id == id)
			   .Include(p => p.FoodCategories)
			   .ThenInclude(pc => pc.Category)
			   .FirstOrDefaultAsync();
		}

		public async Task CreateFoodAsync(Food food, int[] selectedCategoryIds, string recipeMaking)
		{
			//Önce food kaydı yapacağız. Böylece elimizde food Id olacak.
			//Sonra recipe kaydı yap

			//Sonra da bu food Id ve recipe Id'yi kullanarak, foodCategory kaydını/kayıtlarını yapacağız.
			//1) FoodCategory -> FoodId-CategoryId
			//2) FoodRecipe -> FoodId-RecipeId
			await YemekTarifiAppContext.Foods.AddAsync(food);
			await YemekTarifiAppContext.SaveChangesAsync();

			food.FoodCategories = selectedCategoryIds
		  .Select(catId => new FoodCategory
		  {
			  FoodId = food.Id,
			  CategoryId = catId
		  }).ToList();

			Recipe recipe = new Recipe
			{
				Owner = "Serhat",
				OwnerMail = "serhat@gmail.com",
				RecipeMaking = "Buraya yemek bilgilerini gireceğiz."
			};
			await YemekTarifiAppContext.Recipes.AddAsync(recipe);
			await YemekTarifiAppContext.SaveChangesAsync();

			food.FoodRecipes = selectedCategoryIds
		  .Select(recId => new FoodRecipe
		  {
			  FoodId = food.Id,
			  RecipeId = recId
		  }).ToList();

		}

		public async Task UpdateFoodAsync(Food food, int[] selectedCategoryIds)
		{
			Food newFood = await YemekTarifiAppContext
			   .Foods
			   .Include(p => p.FoodCategories)
			   .FirstOrDefaultAsync(p => p.Id == food.Id);
			newFood.FoodCategories = selectedCategoryIds
				.Select(catId => new FoodCategory
				{
					FoodId = newFood.Id,
					CategoryId = catId
				}).ToList();
			YemekTarifiAppContext.Update(newFood);
			await YemekTarifiAppContext.SaveChangesAsync();
		}

		public async Task UpdateIsHomeAsync(Food food)
		{
			food.IsHome = !food.IsHome;
			YemekTarifiAppContext.Update(food);
			await YemekTarifiAppContext.SaveChangesAsync();
		}

		public async Task UpdateIsApprovedAsync(Food food)
		{
			food.IsApproved = !food.IsApproved;
			YemekTarifiAppContext.Update(food);
			await YemekTarifiAppContext.SaveChangesAsync();
		}

		public Task<List<Food>> GetSearchResultsAsync(Expression<Func<Food, bool>> predicate)
		{
			return null;
		}

		public async Task CreateCommentAsync(Comment comment)
		{
			await YemekTarifiAppContext.Comments.AddAsync(comment);
			await YemekTarifiAppContext.SaveChangesAsync();
			new Comment
			{
				Id = comment.Id,
				Name = comment.Name,
				Mail = comment.Mail,
				Details = comment.Details,
				Confirmation = comment.Confirmation,
			};
			await YemekTarifiAppContext.SaveChangesAsync();
		}

		
	}
}
