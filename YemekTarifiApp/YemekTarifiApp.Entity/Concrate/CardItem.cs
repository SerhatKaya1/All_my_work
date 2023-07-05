using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifiApp.Entity.Abstract;

namespace YemekTarifiApp.Entity.Concrate
{
    public class CardItem : IEntityBase
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int Quantity { get; set; }
    }
}
