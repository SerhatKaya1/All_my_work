using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifiApp.Entity.Concrate;

namespace YemekTarifiApp.Data.Abstract
{
    public interface ICardRepository : IRepository<Card>
    {
        Task AddToCard(string userId, int foodId, int quatity);
        Task<Card> GetCardByUserId(string userId);
    }
}
