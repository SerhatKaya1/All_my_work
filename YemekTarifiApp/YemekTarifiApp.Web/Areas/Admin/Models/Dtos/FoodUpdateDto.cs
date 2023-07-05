using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using YemekTarifiApp.Entity;

namespace YemekTarifiApp.Web.Areas.Admin.Models.Dtos
{
	public class FoodUpdateDto
	{
		public int Id { get; set; }

		[DisplayName("Yemek Adı")]
		[Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
		[MinLength(5, ErrorMessage = "{0}, {1} karakterden kısa olmamalıdır.")]
		[MaxLength(100, ErrorMessage = "{0}, {1} karakterden uzun olmamalıdır.")]
		public string Name { get; set; }

		[DisplayName("Malzeme")]
		[Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
		[MinLength(5, ErrorMessage = "{0}, {1} karakterden kısa olmamalıdır.")]
		[MaxLength(500, ErrorMessage = "{0}, {1} karakterden uzun olmamalıdır.")]
		public string Material { get; set; }

        [DisplayName("Yemek Tarifi")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0}, {1} karakterden kısa olmamalıdır.")]
        [MaxLength(500, ErrorMessage = "{0}, {1} karakterden uzun olmamalıdır.")]
        public string RecipeMaking { get; set; }

        [DisplayName("Açıklama")]
		[Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
		[MinLength(5, ErrorMessage = "{0}, {1} karakterden kısa olmamalıdır.")]
		[MaxLength(500, ErrorMessage = "{0}, {1} karakterden uzun olmamalıdır.")]
		public string Description { get; set; }

		[DisplayName("Yemek Resmi")]
		[Required(ErrorMessage = "{0} seçilmelidir.")]
		public IFormFile ImageFile { get; set; }

		[DisplayName("Anasayfa Yemeği")]
		public bool IsHome { get; set; }

		[DisplayName("Onaylı Yemek")]
		public bool IsApproved { get; set; }

		[DisplayName("Kategoriler")]
		public List<Category> Categories { get; set; }

		[Required(ErrorMessage = "En az bir kategori seçilmelidir.")]
		public int[] SelectedCategoryIds { get; set; }
		public string ImageUrl { get; set; }
	}
}
