using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifiApp.Data.Abstract;
using YemekTarifiApp.Data.Concrete.EfCore.Contexts;
using YemekTarifiApp.Data.Concrete.EfCore.Repositories;

namespace YemekTarifiApp.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly YemekTarifiAppContext _context;

        public UnitOfWork(YemekTarifiAppContext context)
        {
            _context = context;
        }

        private EfCoreCategoryRepository _categoryRepository;
        private EfCoreFoodRepository _foodRepository;
        private EfCoreCardRepository _cardRepository;

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new EfCoreCategoryRepository(_context);

        public IFoodRepository Foods => _foodRepository = _foodRepository ?? new EfCoreFoodRepository(_context);

        public ICardRepository Cards => _cardRepository = _cardRepository ?? new EfCoreCardRepository(_context);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
           _context.Dispose();
        }
    }
}
