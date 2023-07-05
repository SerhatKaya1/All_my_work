using ShoppingApp.Business.Abstract;
using ShoppingApp.Data.Abstract;
using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Generics
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task CreateAsync(Product product)
        {
            await _unitOfWork.Products.CreateAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public void Update(Product product)
        {
            _unitOfWork.Products.Update(product);
            _unitOfWork.Save();
        }

        public void Delete(Product product)
        {
            _unitOfWork.Products.Delete(product);
            _unitOfWork.Save();
        }
        #endregion

        #region Products
        public async Task<List<Product>> GetHomePageProductsAsync()
        {
            return await _unitOfWork.Products.GetHomePageProductsAsync();
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(string category)
        {
            return await _unitOfWork.Products.GetProductsByCategoryAsync(category);
        }

        public async Task<Product> GetProductDetailsByUrlAsync(string productUrl)
        {
            return await _unitOfWork.Products.GetProductDetailsByUrlAsync(productUrl);
        }

        public async Task<List<Product>> GetProductsWithCategories()
        {
            return await _unitOfWork.Products.GetProductsWithCategories();
        }

        public async Task CreateProductAsync(Product product, int[] selectedCategroyIds)
        {
            await _unitOfWork.Products.CreateProductAsync(product, selectedCategroyIds);
        }

        public async Task<Product> GetProductWithCategories(int id)
        {
            return await _unitOfWork.Products.GetProductWithCategories(id);
        }

        public async Task UpdateProductAsync(Product product, int[] selectedCategoryIds)
        {
            await _unitOfWork.Products.UpdateProductAsync(product, selectedCategoryIds);
        }

        public async Task UpdateIsHomeAsync(Product product)
        {
            await _unitOfWork.Products.UpdateIsHomeAsync(product);
        }

        public async Task UpdateIsApprovedAsync(Product product)
        {
            await _unitOfWork.Products.UpdateIsApprovedAsync(product);
        }

        public async Task<List<Product>> GetSearchResultsAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _unitOfWork.Products.GetSearchResultsAsync(predicate);
        }
        #endregion
    }
}
