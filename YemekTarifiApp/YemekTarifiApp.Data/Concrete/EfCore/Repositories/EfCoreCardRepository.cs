using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifiApp.Data.Abstract;
using YemekTarifiApp.Data.Concrete.EfCore.Contexts;
using YemekTarifiApp.Entity.Concrate;

namespace YemekTarifiApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCardRepository : EfCoreGenericRepository<Card>, ICardRepository
    {
        public EfCoreCardRepository(YemekTarifiAppContext context) : base(context)
        {

        }

         private YemekTarifiAppContext YemekTarifiContext
        {
            get { return _context as YemekTarifiAppContext; }
        }

        public Task AddToCard(string userId, int foodId, int quatity)
        {
            throw new NotImplementedException();
        }

        public Task<Card> GetCardByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
