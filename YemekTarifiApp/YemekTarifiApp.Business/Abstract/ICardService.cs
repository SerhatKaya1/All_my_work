using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifiApp.Entity.Concrate;

namespace YemekTarifiApp.Business.Abstract
{
    public interface ICardService
    {
        Task InitializeCard(string userId);
        Task AddToCard(string userId, int foodtId, int quantity);
        Task<Card> GetByIdAsync(int id);
        Task<Card> GetCardByUserId(string userId);
    }
}
