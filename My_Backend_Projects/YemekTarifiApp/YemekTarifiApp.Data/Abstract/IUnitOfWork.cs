using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekTarifiApp.Data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IFoodRepository Foods { get; }
        ICardRepository Cards { get; }
        Task SaveAsync();
        void Save();
    }
}
