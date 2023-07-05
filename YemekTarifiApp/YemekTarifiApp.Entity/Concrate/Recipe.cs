using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifiApp.Entity.Abstract;

namespace YemekTarifiApp.Entity.Concrate
{
    public class Recipe : IEntityBase  //Yemek tarifi
    {
        public int Id { get; set; }
        public string RecipeMaking { get; set; } //Tarif Yapılışı
        public string Owner { get; set; } //Yemek Sahibi
        public string OwnerMail { get; set; } //Yemek Sahibi Maili
        public List<FoodRecipe> FoodRecipes { get; set; } 
       

    }
}
