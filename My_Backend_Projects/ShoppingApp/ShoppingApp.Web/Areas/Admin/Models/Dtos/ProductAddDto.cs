using ShoppingApp.Entity.Concrete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ShoppingApp.Web.Areas.Admin.Models.Dtos
{
    public class ProductAddDto
    {
        [DisplayName("Ürün Adı")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0}, {1} karakterden kısa olmamalıdır.")]
        [MaxLength(100, ErrorMessage = "{0}, {1} karakterden uzun olmamalıdır.")]
        public string Name { get; set; }

        [DisplayName("Fiyatı")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        public decimal? Price { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0}, {1} karakterden kısa olmamalıdır.")]
        [MaxLength(500, ErrorMessage = "{0}, {1} karakterden uzun olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Ürün Resmi")]
        [Required(ErrorMessage = "{0} seçilmelidir.")]
        public IFormFile ImageFile { get; set; }

        [DisplayName("Anasayfa Ürünü")]
        public bool IsHome { get; set; }

        [DisplayName("Onaylı Ürün")]
        public bool IsApproved { get; set; }

        [DisplayName("Kategoriler")]
        public List<Category> Categories { get; set; }

        [Required(ErrorMessage ="En az bir kategori seçilmelidir.")]
        public int[] SelectedCategoryIds { get; set; }
        public string ImageUrl { get; set; }
    }
}
