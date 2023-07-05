using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifiApp.Entity.Abstract;
using YemekTarifiApp.Entity.Concrate.Identity;

namespace YemekTarifiApp.Entity.Concrate
{
    public class Card : IEntityBase
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<CardItem> CardItems { get; set; }
    }
}
