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
    public class FoodCategoryConfig : IEntityTypeConfiguration<FoodCategory>
    {
        public void Configure(EntityTypeBuilder<FoodCategory> builder)
        {
            builder.HasKey(fc => new { fc.FoodId, fc.CategoryId });

            builder.ToTable("FoodCategories");

            builder.HasData(
                
                new FoodCategory { FoodId = 1, CategoryId = 1 },
                new FoodCategory { FoodId = 2, CategoryId = 1 },
                new FoodCategory { FoodId = 3, CategoryId = 1 },
                new FoodCategory { FoodId = 4, CategoryId = 1 },
                new FoodCategory { FoodId = 5, CategoryId = 1 },
                new FoodCategory { FoodId = 6, CategoryId = 2 },
                new FoodCategory { FoodId = 7, CategoryId = 2 },
                new FoodCategory { FoodId = 8, CategoryId = 2 },
                new FoodCategory { FoodId = 9, CategoryId = 2 },
                new FoodCategory { FoodId = 10, CategoryId = 2 },
                new FoodCategory { FoodId = 11, CategoryId = 3 },
                new FoodCategory { FoodId = 12, CategoryId = 3 },
                new FoodCategory { FoodId = 13, CategoryId = 3 },
                new FoodCategory { FoodId = 14, CategoryId = 3 },
                new FoodCategory { FoodId = 15, CategoryId = 3 },
                new FoodCategory { FoodId = 16, CategoryId = 4 },
                new FoodCategory { FoodId = 17, CategoryId = 4 },
                new FoodCategory { FoodId = 18, CategoryId = 4 },
                new FoodCategory { FoodId = 19, CategoryId = 4 },
                new FoodCategory { FoodId = 20, CategoryId = 4 },
                new FoodCategory { FoodId = 21, CategoryId = 5 },
                new FoodCategory { FoodId = 22, CategoryId = 5 },
                new FoodCategory { FoodId = 23, CategoryId = 5 },
                new FoodCategory { FoodId = 24, CategoryId = 5 },
                new FoodCategory { FoodId = 25, CategoryId = 5 },
                new FoodCategory { FoodId = 26, CategoryId = 6 },
                new FoodCategory { FoodId = 27, CategoryId = 6 },
                new FoodCategory { FoodId = 28, CategoryId = 6 },
                new FoodCategory { FoodId = 29, CategoryId = 6 },
                new FoodCategory { FoodId = 30, CategoryId = 6 },
                new FoodCategory { FoodId = 31, CategoryId = 7 },
                new FoodCategory { FoodId = 32, CategoryId = 7 },
                new FoodCategory { FoodId = 33, CategoryId = 7 },
                new FoodCategory { FoodId = 34, CategoryId = 7 },
                new FoodCategory { FoodId = 35, CategoryId = 7 },
                new FoodCategory { FoodId = 36, CategoryId = 8 },
                new FoodCategory { FoodId = 37, CategoryId = 8 },
                new FoodCategory { FoodId = 38, CategoryId = 8 },
                new FoodCategory { FoodId = 39, CategoryId = 8 },
                new FoodCategory { FoodId = 40, CategoryId = 8 }
                );
        }

    }
}
/*
 Burada aynı kategoride birden fazla yemek olabiliyor .Ancak her yemek bir kategoriye gidecek şekilde yaptım . ilk başta aynı yemek
yada içecek birden fazla kategoride olabilir diyerek düşünerek başladım sonra vazgeçtim bu şekilde yaptım.
 */
