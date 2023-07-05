using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KitabeviApp.Models
{
    public class KitabeviContext : DbContext
    {
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Kitabevi.Db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>()
                .HasData(
                    new Kategori() { Id = 1, Ad = "Çocuk", Aciklama = "Çocuk Kitapları" },
                    new Kategori() { Id = 2, Ad = "Edebiyat", Aciklama = "Roman, Hikaye, Şiir Kitapları" },
                    new Kategori() { Id = 3, Ad = "Bilgisayar", Aciklama = "Bilgisayar Kitapları" },
                    new Kategori() { Id = 4, Ad = "Akademik", Aciklama = "Akademik Kitaplar" }
                );

            modelBuilder.Entity<Yazar>()
                .HasData(
                    new Yazar() { Id = 1, Ad = "Matt Heig", DogumYili = 1980, Cinsiyet = 'E' },
                    new Yazar() { Id = 2, Ad = "Feyyaz Yiğit", DogumYili = 1990, Cinsiyet = 'E' },
                    new Yazar() { Id = 3, Ad = "Gizem Doğan", DogumYili = 1960, Cinsiyet = 'K' },
                    new Yazar() { Id = 4, Ad = "Jack London", DogumYili = 1930, Cinsiyet = 'E' },
                    new Yazar() { Id = 5, Ad = "Margaret Atwood", DogumYili = 1980, Cinsiyet = 'K' },
                    new Yazar() { Id = 6, Ad = "Cem Akaş", DogumYili = 1980, Cinsiyet = 'E' },
                    new Yazar() { Id = 7, Ad = "Zafer Demirkol", DogumYili = 1980, Cinsiyet = 'E' },
                    new Yazar() { Id = 8, Ad = "İlber Ortaylı", DogumYili = 1980, Cinsiyet = 'E' },
                    new Yazar() { Id = 9, Ad = "Seda Yiğit", DogumYili = 1980, Cinsiyet = 'K' },
                    new Yazar() { Id = 10, Ad = "George Orwell", DogumYili = 1980, Cinsiyet = 'E' }
                );
            modelBuilder.Entity<Kitap>()
                .HasData(
                    new Kitap() { AnaSayfa=true, Id = 1, Ad = "İnsanlar", BasimYili = 2021, SayfaSayisi = 330, KategoriId = 2, YazarId = 1, Ozet = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore magnam animi sapiente quos atque voluptatem, at molestias eum eius quia quod nostrum cum eos maiores doloribus veniam reprehenderit natus laboriosam." },
                    
                    new Kitap() {AnaSayfa=true, Id = 2, Ad = "Zamanı Durdurmanın Yolları", BasimYili = 2021, SayfaSayisi = 370, KategoriId = 1, YazarId = 1, Ozet = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore magnam animi sapiente quos atque voluptatem, at molestias eum eius quia quod nostrum cum eos maiores doloribus veniam reprehenderit natus laboriosam." },
                    
                    new Kitap() {AnaSayfa=true, Id = 3, Ad = "Demir Ökçe", BasimYili = 2017, SayfaSayisi = 400, KategoriId = 2, YazarId = 4, Ozet = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore magnam animi sapiente quos atque voluptatem, at molestias eum eius quia quod nostrum cum eos maiores doloribus veniam reprehenderit natus laboriosam." },
                    
                    new Kitap() {AnaSayfa=true, Id = 4, Ad = "Huzursuzluk", BasimYili = 2018, SayfaSayisi = 330, KategoriId = 2, YazarId = 9, Ozet = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore magnam animi sapiente quos atque voluptatem, at molestias eum eius quia quod nostrum cum eos maiores doloribus veniam reprehenderit natus laboriosam." },
                    
                    new Kitap() { Id = 5, Ad = "Serenad", BasimYili = 2020, SayfaSayisi = 300, KategoriId = 2, YazarId = 9, Ozet = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore magnam animi sapiente quos atque voluptatem, at molestias eum eius quia quod nostrum cum eos maiores doloribus veniam reprehenderit natus laboriosam." },
                    
                    new Kitap() { Id = 6, Ad = "19", BasimYili = 2016, SayfaSayisi = 380, KategoriId = 2, YazarId = 6, Ozet = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore magnam animi sapiente quos atque voluptatem, at molestias eum eius quia quod nostrum cum eos maiores doloribus veniam reprehenderit natus laboriosam." },
                    
                    new Kitap() { Id = 7, Ad = "C# Programlama Dili", BasimYili = 2011, SayfaSayisi = 730, KategoriId = 3, YazarId = 7, Ozet = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore magnam animi sapiente quos atque voluptatem, at molestias eum eius quia quod nostrum cum eos maiores doloribus veniam reprehenderit natus laboriosam." },
                    
                    new Kitap() { Id = 8, Ad = "React Uygulama Geliştirme", BasimYili = 2021, SayfaSayisi = 530, KategoriId = 3, YazarId = 3, Ozet = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore magnam animi sapiente quos atque voluptatem, at molestias eum eius quia quod nostrum cum eos maiores doloribus veniam reprehenderit natus laboriosam." },
                    
                    new Kitap() { Id = 9, Ad = "İnsan Ömrünü Neyle Geçirmeli?", BasimYili = 2021, SayfaSayisi = 330, KategoriId = 2, YazarId = 8, Ozet = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Labore magnam animi sapiente quos atque voluptatem, at molestias eum eius quia quod nostrum cum eos maiores doloribus veniam reprehenderit natus laboriosam." }
                );
        }
    }
}