using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifiApp.Data.Abstract;
using YemekTarifiApp.Entity;

namespace YemekTarifiApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(DbContext context) : base(context)
        {

        }

        public Category GetByIdWithProducts()
        {
            throw new NotImplementedException();
        }
    }
}
