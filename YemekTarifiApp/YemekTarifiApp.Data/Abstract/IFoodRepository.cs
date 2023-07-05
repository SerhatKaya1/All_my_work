using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YemekTarifiApp.Entity.Concrate;

namespace YemekTarifiApp.Data.Abstract
{
    public interface IFoodRepository : IRepository<Food>
    {
        Task<Food> GetFoodDetailsByUrlAsync(string foodUrl); //food detaylarını url e göre getir.
        Task<List<Food>> GetFoodsByCategoryAsync(string category);
        Task<List<Food>> GetHomePageFoodsAsync();
        Task<List<Food>> GetFoodsWithCategories();
		Task<Food> GetFoodWithCategories(int id);
		Task CreateFoodAsync(Food food, int[] selectedCategoryIds, string recipeMaking);
		Task CreateCommentAsync(Comment comment);
		Task UpdateFoodAsync(Food food, int[] selectedCategoryIds);
        Task UpdateIsHomeAsync(Food food);
        Task UpdateIsApprovedAsync(Food food);
        Task<List<Food>> GetSearchResultsAsync(Expression<Func<Food, bool>> predicate);

    }
}
