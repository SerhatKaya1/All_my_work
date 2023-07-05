using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekTarifiApp.Entity.Concrate
{
    public class FoodCategory
    {
        public Category Category { get; set; } 
        public int CategoryId { get; set; } 
        public int FoodId { get; set; } 
        public Food Food { get; set; } 
    }
}
