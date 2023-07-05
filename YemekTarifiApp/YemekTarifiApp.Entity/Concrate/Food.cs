using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifiApp.Entity.Abstract;

namespace YemekTarifiApp.Entity.Concrate
{
    public class Food : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; } //Resim çok fazla alan kaplayacağı için dosya uzantısı olarak yazacağız.
        public DateTime AddDate { get; set; }
        public int Point { get; set; }
        public bool IsHome { get; set; } 
        public bool IsApproved { get; set; } //Onaylanma
        public List<FoodCategory> FoodCategories { get; set; } 
        public List<FoodRecipe> FoodRecipes { get; set; }
        public List<Comment> Comments { get; set; } //bir yemeğe birden fazla yorum yapılabilir.


    }
}
