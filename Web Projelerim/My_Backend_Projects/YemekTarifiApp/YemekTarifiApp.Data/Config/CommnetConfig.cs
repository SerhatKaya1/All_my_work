using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifiApp.Entity;
using YemekTarifiApp.Entity.Concrate;

namespace YemekTarifiApp.Data.Config
{
    public class CommnetConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(cc => cc.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(cc => cc.Name)
               .IsRequired()
               .HasMaxLength(50);


            builder.Property(cc => cc.Mail)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(cc => cc.DateAdded)
               .HasDefaultValueSql("date('now')");

            builder.Property(cc => cc.Details)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(cc => cc.Confirmation)
              .IsRequired()
              .HasMaxLength(250);




            builder.ToTable("Comments");
            builder.HasData(

              new Comment { Id = 1, FoodId=1, Name = "Serhat Kaya", Mail = "serhatkaya2496@gmail.com", Details = "Bu yemek bir harika.", Confirmation = false }, //hareket içerikli yorumları engellemek için başlangıç değerini false aldık.
              new Comment { Id = 2, FoodId=2, Name = "ALİ Onur",  Mail = "AliOnur25@gmail.com", Details = "Bu yemek bir harika.", Confirmation = false },
              new Comment { Id = 3, FoodId=3, Name = "Ramazan Babayiğit",  Mail = "r.bab96@gmail.com",  Details = "Bu yemek bir harika.", Confirmation = false },
              new Comment { Id = 4,FoodId=3, Name = "Serkan Kaya",  Mail = "seko94@gmail.com", Details = "Bu yemek bir harika.", Confirmation = false },
              new Comment { Id = 5, FoodId=4, Name = "Ayşegül Karakaş",  Mail = "Aysegul86@gmail.com", Details = "Bu yemek bir harika.", Confirmation = false },
              new Comment { Id = 6, FoodId=6, Name = "Halit Ziya Uşaklıgil",  Mail = "hziyausakligil@gmail.com", Details = "", Confirmation = false },
              new Comment { Id = 7,FoodId=10, Name = "Ömer Seyfettin",  Mail = "#oseyfettin@gmail.com", Details = "Bu yemek bir harika.", Confirmation = false },
              new Comment { Id = 8, FoodId=15, Name = "Pablo Picasso",  Mail = "ppicasso10@gmail.com", Details = "Bu yemek bir harika.", Confirmation = false },
              new Comment { Id = 9,FoodId=18, Name = "Ali Koç",  Mail = "alikoc@gmail.com", Details = "Bu yemek bir harika.", Confirmation = false },
              new Comment { Id = 10,FoodId=20, Name = "Nesrin Yılmaz",  Mail = "nesrinylmz@gmail.com", Details = "Bu yemek bir harika.", Confirmation = false }


               );
        }
    }
}
