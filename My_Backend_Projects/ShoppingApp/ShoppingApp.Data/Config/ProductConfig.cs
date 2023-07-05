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
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.ImageUrl)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(p => p.Url)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("money");

            builder.Property(p => p.DateAdded)
                //.HasDefaultValueSql("getdate()");
                .HasDefaultValueSql("date('now')");//Sqlite
                                                   //.HasDefaultValueSql("getdate()"); (Bu sql server ile çalışırken kullanma şeklimiz)

            builder.ToTable("Products");

            builder.HasData(
                new Product { Id=1, Name="Samsung S20", Price=24500, 
                    Description="Kamerası son teknoloji!", ImageUrl="1.png", 
                    Url="samsung-s20", IsHome=true, IsApproved=true},

                new Product { Id=2, Name="Samsung S21", Price=34500, 
                    Description="Kamerası son teknoloji, 5G!", ImageUrl="2.png", 
                    Url="samsung-s21", IsHome=false, IsApproved=true},

                new Product { Id=3, Name="Iphone 13", Price=21500, 
                    Description="Güzel bir telefon", ImageUrl="3.png", 
                    Url="iphone-13", IsHome=false, IsApproved=true},

                new Product { Id=4, Name="Iphone 14 Pro", Price=34500, 
                    Description="Kamerası son teknoloji!", ImageUrl="4.png", 
                    Url="iphone-14-pro", IsHome=false, IsApproved=true},

                new Product { Id=5, Name="IPad 12", Price=4500, 
                    Description="Kamerası son teknoloji!", ImageUrl="5.png", 
                    Url="ipad-12", IsHome=true, IsApproved=false},

                new Product { Id=6, Name="Type C Usb Bağlantı Kablosu", Price=400, 
                    Description="1.5 metre", ImageUrl="15.png", 
                    Url="type-c-usb-baglanti-kablosu", IsHome=false, IsApproved=true},

                new Product { Id=7, Name="Vestel CM123", Price=9500, 
                    Description="Tam otomatik çamaşır makinesi", ImageUrl="20.png", 
                    Url="vestel-cm123", IsHome=true, IsApproved=true},

                new Product { Id=8, Name="Arçelik Türk Kahvesi Makinesi TK8", Price=24500, 
                    Description="Köpüklü Türk kahvesi keyfi", ImageUrl="16.png", 
                    Url="arcelik-turk-kahvesi-makinesi-tk8", IsHome=true, IsApproved=true},

                new Product { Id=9, Name="Macbook Air M2", Price=29500, 
                    Description="M2 işlemcinin gücü", ImageUrl="17.png", 
                    Url="macbook-air-m2", IsHome=false, IsApproved=true},

                new Product { Id=10, Name="Asus Tulpar G45", Price=26500, 
                    Description="I9 işlemci", ImageUrl="21.png", 
                    Url="asus-tulpar-g45", IsHome=false, IsApproved=true},

                new Product { Id=11, Name="Lenovo K234", Price=19000, 
                    Description="İş için ideal", ImageUrl="22.png", 
                    Url="lenovo-k234", IsHome=false, IsApproved=true},

                new Product { Id=12, Name="Samsung NF34 Buzdolabı", Price=13000, 
                    Description="Derin donduruculu", ImageUrl="19.png", 
                    Url="samsung-nf34-buzdolabi", IsHome=false, IsApproved=false}
                );

        }
    }
}
