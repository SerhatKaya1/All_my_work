using Microsoft.EntityFrameworkCore.Storage;

namespace YemekTarifiApp.Web.Models.Dtos
{
    public class FoodDto
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }

    }
}

/*
 DTO (Data Transfer Object)
View model son kullanıcıya gösterilecek veriyi döndürmek için kullanılırkeni Dto uygulama katmanları arasında veriyi transfer etmek için
kullanılır. Genel olarak database den gelen veriyi source olarak kullanır.
 */
