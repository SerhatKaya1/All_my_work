using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ShoppingApp.Web.Areas.Admin.Models.Dtos
{
    public class CategoryUpdateDto
    {
        public int Id { get; set; }

        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0}, {1} karakterden kısa olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0}, {1} karakterden uzun olmamalıdır.")]
        public string Name { get; set; }


        [DisplayName("Kategori Açıklaması")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        [MinLength(10, ErrorMessage = "{0}, {1} karakterden kısa olmamalıdır.")]
        [MaxLength(500, ErrorMessage = "{0}, {1} karakterden uzun olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Kategori Url")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        public string Url { get; set; }
    }
}
