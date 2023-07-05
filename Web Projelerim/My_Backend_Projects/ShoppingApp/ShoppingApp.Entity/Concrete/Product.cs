using ShoppingApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Concrete
{
    public class Product : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public bool IsHome { get; set; }
        public bool IsApproved { get; set; }
        public DateTime DateAdded { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public int Deneme { get; set; }
    }
}
