using ShoppingApp.Data.Abstract;
using ShoppingApp.Data.Concrete.EfCore.Contexts;
using ShoppingApp.Data.Concrete.EfCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly ShopAppContext _context;

        public UnitOfWork(ShopAppContext context)
        {
            _context = context;
        }

        private EfCoreCategoryRepository _categoryRepository;
        private EfCoreProductRepository _productRepository;
        private EfCoreCardRepository _cardRepository;
        private EfCoreCardItemRepository _cardItemRepository;
        private EfCoreOrderRepository _orderRepository;

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new EfCoreCategoryRepository(_context);

        public IProductRepository Products => _productRepository=_productRepository ?? new EfCoreProductRepository(_context);

        public ICardRepository Cards => _cardRepository=_cardRepository ?? new EfCoreCardRepository(_context);

        public ICardItemRepository CardItems => _cardItemRepository = _cardItemRepository ?? new EfCoreCardItemRepository(_context);

        public IOrderRepository Orders => _orderRepository = _orderRepository ?? new EfCoreOrderRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
