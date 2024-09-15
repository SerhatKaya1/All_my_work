using YemekTarifiApp.Entity;
using YemekTarifiApp.Entity.Concrate;

namespace YemekTarifiApp.Web.Models.Dtos
{
    public class FoodDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public int Point { get; set; }
        public List<Category> Categories { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
