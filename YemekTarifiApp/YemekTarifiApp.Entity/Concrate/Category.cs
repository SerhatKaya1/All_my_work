using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifiApp.Entity.Abstract;
using YemekTarifiApp.Entity.Concrate;

namespace YemekTarifiApp.Entity
{
    public class Category : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public List<FoodCategory> FoodCategories { get; set;}  
    }
}
