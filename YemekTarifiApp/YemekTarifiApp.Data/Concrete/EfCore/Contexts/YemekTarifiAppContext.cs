using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifiApp.Data.Config;
using YemekTarifiApp.Entity;
using YemekTarifiApp.Entity.Concrate;
using YemekTarifiApp.Entity.Concrate.Identity;

namespace YemekTarifiApp.Data.Concrete.EfCore.Contexts
{
    public class YemekTarifiAppContext : IdentityDbContext<User, Role, string>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        

        public DbSet<FoodRecipe> FoodRecipes { get; set; }

        public YemekTarifiAppContext(DbContextOptions<YemekTarifiAppContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new CommnetConfig());
            modelBuilder.ApplyConfiguration(new FoodConfig());
            modelBuilder.ApplyConfiguration(new RecipeConfig());
            modelBuilder.ApplyConfiguration(new FoodCategoryConfig());
           
            modelBuilder.ApplyConfiguration(new FoodRecipeConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
/*
         * Connection String ne işe yarar?
ConnectionString nedir ? Bağlantının yapılabilmesi için gerekli olan : hangi ana makine'ye 
bağlantı yapılacağını, o ana makinedeki hangi veritabanına bağlanacağımızı, 
o veritabanına bağlanmak için gerekli olan kullanıcı adı ve şifresi gibi bilgilerin 
tutulduğu bir kod parçasıdır.
         */
