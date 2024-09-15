using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifiApp.Entity.Concrate;

namespace YemekTarifiApp.Data.Config
{
    public class FoodRecipeConfig : IEntityTypeConfiguration<FoodRecipe>
    {
        public void Configure(EntityTypeBuilder<FoodRecipe> builder)
        {
            builder.HasKey(fro => new { fro.FoodId, fro.RecipeId });
            builder.ToTable("FoodRecipes");
            builder.HasData(
                
                new FoodRecipe { FoodId = 1, RecipeId = 1 },
                new FoodRecipe { FoodId = 2, RecipeId = 2 },
                new FoodRecipe { FoodId = 3, RecipeId = 3 },
                new FoodRecipe { FoodId = 4, RecipeId = 4 },
                new FoodRecipe { FoodId = 5, RecipeId = 5 },
                new FoodRecipe { FoodId = 6, RecipeId = 6 },
                new FoodRecipe { FoodId = 7, RecipeId = 7 },
                new FoodRecipe { FoodId = 8, RecipeId = 8 },
                new FoodRecipe { FoodId = 9, RecipeId = 9 },
                new FoodRecipe { FoodId = 10, RecipeId = 10 },
                new FoodRecipe { FoodId = 11, RecipeId = 11 },
                new FoodRecipe { FoodId = 12, RecipeId = 12 },
                new FoodRecipe { FoodId = 13, RecipeId = 13 },
                new FoodRecipe { FoodId = 14, RecipeId = 14 },
                new FoodRecipe { FoodId = 15, RecipeId = 15 },
                new FoodRecipe { FoodId = 16, RecipeId = 16 },
                new FoodRecipe { FoodId = 17, RecipeId = 17 },
                new FoodRecipe { FoodId = 18, RecipeId = 18 },
                new FoodRecipe { FoodId = 19, RecipeId = 19 },
                new FoodRecipe { FoodId = 20, RecipeId = 20 },
                new FoodRecipe { FoodId = 21, RecipeId = 21 },
                new FoodRecipe { FoodId = 22, RecipeId = 22 },
                new FoodRecipe { FoodId = 23, RecipeId = 23 },
                new FoodRecipe { FoodId = 24, RecipeId = 24 },
                new FoodRecipe { FoodId = 25, RecipeId = 25 },
                new FoodRecipe { FoodId = 26, RecipeId = 26 },
                new FoodRecipe { FoodId = 27, RecipeId = 27 },
                new FoodRecipe { FoodId = 28, RecipeId = 28 },
                new FoodRecipe { FoodId = 29, RecipeId = 29 },
                new FoodRecipe { FoodId = 30, RecipeId = 30 },
                new FoodRecipe { FoodId = 31, RecipeId = 31 },
                new FoodRecipe { FoodId = 32, RecipeId = 32 },
                new FoodRecipe { FoodId = 33, RecipeId = 33 },
                new FoodRecipe { FoodId = 34, RecipeId = 34 },
                new FoodRecipe { FoodId = 35, RecipeId = 35 },
                new FoodRecipe { FoodId = 36, RecipeId = 36 },
                new FoodRecipe { FoodId = 37, RecipeId = 37 },
                new FoodRecipe { FoodId = 38, RecipeId = 38 },
                new FoodRecipe { FoodId = 39, RecipeId = 39 },
                new FoodRecipe { FoodId = 40, RecipeId = 40 }
                );
        }
    }
}
/*
 İlk başta aynı yemeğe birden Fazla YAPILIŞ TARİFİ TANIMLAMAYI düşündüm . Daha sonra proje zamanı ve uğraş süresini baz alınca 
compozit olarak 1 yemek 1 tarife sahip olsun şeklinde kompozit olarak tanımladım.
 */