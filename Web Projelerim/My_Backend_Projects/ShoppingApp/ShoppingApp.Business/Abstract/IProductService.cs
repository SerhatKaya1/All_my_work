using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Business.Abstract
{
    public interface IProductService
    {
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task CreateAsync(Product product);
        Task CreateProductAsync(Product product, int[] selectedCategroyIds);
        void Update(Product product);
        Task UpdateProductAsync(Product product, int[] selectedCategoryIds);
        void Delete(Product product);
        Task<List<Product>> GetProductsByCategoryAsync(string category);
        Task<List<Product>> GetHomePageProductsAsync();
        Task<Product> GetProductDetailsByUrlAsync(string productUrl);
        Task<List<Product>> GetProductsWithCategories();
        Task<Product> GetProductWithCategories(int id);
        Task UpdateIsHomeAsync(Product product);
        Task UpdateIsApprovedAsync(Product product);
        Task<List<Product>> GetSearchResultsAsync(Expression<Func<Product, bool>> predicate);
    }
}
