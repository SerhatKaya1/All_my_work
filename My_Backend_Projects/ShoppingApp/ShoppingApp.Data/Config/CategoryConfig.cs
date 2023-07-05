using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Config
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
                new Category { Id = 1, Name = "Telefon", Description = "Telefonlar bu kategoride bulunmaktadır.", Url = "telefon" },
                new Category { Id = 2, Name = "Elektronik", Description = "Elektronik ürünler bu kategoride bulunmaktadır.", Url = "elektronik" },
                new Category { Id = 3, Name = "Bilgisayar", Description = "Bilgisayarlar bu kategoride bulunmaktadır.", Url = "bilgisayar" },
                new Category { Id = 4, Name = "Beyaz Eşya", Description = "Beyaz eşyalar bu kategoride bulunmaktadır.", Url = "beyaz-esya" });

        }
    }
}
