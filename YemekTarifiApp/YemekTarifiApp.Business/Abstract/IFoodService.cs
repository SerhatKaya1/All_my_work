using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YemekTarifiApp.Entity.Concrate;

namespace YemekTarifiApp.Business.Abstract
{
    public interface IFoodService
    {
        Task<Food> GetByIdAsync(int id);
        Task<List<Food>> GetAllAsync();
        Task CreateAsync(Food food);
        void Update(Food food);
        void Delete(Food food);
        Task<List<Food>> GetFoodsByCategoryAsync(string category);
        Task<List<Food>> GetHomePageFoodsAsync();
        Task<Food> GetFoodDetailsByUrlAsync(string foodUrl);
        Task<List<Food>> GetFoodsWithCategories();
        Task CreateFoodAsync(Food food, int[] selectedCategroyIds,string recipeMaking);
		Task CreateCommentAsync(Comment comment);
		Task UpdateFoodAsync(Food food, int[] selectedCategoryIds);
        Task<Food> GetFoodWithCategories(int id);
        Task UpdateIsHomeAsync(Food food);
        Task UpdateIsApprovedAsync(Food food);
        Task<List<Food>> GetSearchResultsAsync(Expression<Func<Food, bool>> predicate);
		
	}
}
