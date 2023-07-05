using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        ICardRepository Cards { get; }
        ICardItemRepository CardItems { get; }
        IOrderRepository Orders { get; }
        Task SaveAsync();
        void Save();
    }
}
