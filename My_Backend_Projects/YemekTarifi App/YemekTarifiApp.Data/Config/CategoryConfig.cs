using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifiApp.Entity;

namespace YemekTarifiApp.Data.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(c => c.Url)
              .IsRequired()
              .HasMaxLength(250);


            builder.ToTable("Categories");
            builder.HasData(

               new Category { Id = 1 , Name= "Çorbalar"  , Description="Çorbalar bu Categoride bulunmaktadır" , Url = "Çorbalar"  },
               new Category { Id = 2 , Name= "Et Yemekleri"  , Description="Et Yemekleri bu Categoride bulunmaktadır" , Url = "Et Yemekleri"  },
               new Category { Id = 3 , Name= "Tavuk Yemekleri" ,  Description="Tavuk Yemekleri bu Categoride bulunmaktadır" , Url = "Tavuk Yemekleri"  },
               new Category { Id = 4, Name = "Balık Yemekleri",  Description = "Balık Yemekleri bu Categoride bulunmaktadır", Url = "Balık Yemekleri" },
               new Category { Id = 5, Name = "Zeytinyağlılar",  Description = "Zeytinyağlılar bu Categoride bulunmaktadır", Url = "Zeytinyağlı Yemekler" },
               new Category { Id = 6, Name = "Salatalar",  Description = "Salatalar bu Categoride bulunmaktadır", Url = "Salata Çesitleri" },
               new Category { Id = 7, Name = "Tatlılar",  Description = "Tatlılar bu Categoride bulunmaktadır", Url = "Tatlı Çesitleri" },
               new Category { Id = 8, Name = "İçecekler", Description = "İçecekler bu Categoride bulunmaktadır", Url = "İçecekler" }


                );

        }
    }
}
