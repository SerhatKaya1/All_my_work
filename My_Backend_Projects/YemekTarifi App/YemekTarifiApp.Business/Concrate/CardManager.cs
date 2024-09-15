using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifiApp.Business.Abstract;
using YemekTarifiApp.Data.Abstract;
using YemekTarifiApp.Entity.Concrate;

namespace YemekTarifiApp.Business.Concrate
{
    public class CardManager : ICardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CardManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddToCard(string userId, int foodId, int quantity)
        {
            await _unitOfWork.Cards.AddToCard(userId, foodId, quantity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Card> GetByIdAsync(int id)
        {
            return await _unitOfWork.Cards.GetByIdAsync(id);
        }

        public async Task<Card> GetCardByUserId(string userId)
        {
            return await _unitOfWork.Cards.GetCardByUserId(userId);
        }

        public async Task InitializeCard(string userId)
        {
            await _unitOfWork.Cards.CreateAsync(new Card { UserId = userId });
            await _unitOfWork.SaveAsync();
        }
    }
}
