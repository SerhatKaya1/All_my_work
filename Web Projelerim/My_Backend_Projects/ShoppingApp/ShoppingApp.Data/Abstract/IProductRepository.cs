using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        //Producta özgü memberlar burada olacak.(property, field, method...)ü
        //Örneğin aşağıdakiler gibi:
        Task<List<Product>> GetProductsByCategoryAsync(string category);
        Task<List<Product>> GetHomePageProductsAsync();
        Task<Product> GetProductDetailsByUrlAsync(string productUrl);
        Task<List<Product>> GetProductsWithCategories();
        Task CreateProductAsync(Product product, int[] selectedCategoryIds);
        Task<Product> GetProductWithCategories(int id);
        Task UpdateProductAsync(Product product, int[] selectedCategoryIds);
        Task UpdateIsHomeAsync(Product product);
        Task UpdateIsApprovedAsync(Product product);
        Task<List<Product>> GetSearchResultsAsync(Expression<Func<Product, bool>> predicate);
    }
}
