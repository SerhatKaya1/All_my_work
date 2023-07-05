using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Web.Areas.Admin.Models.Dtos
{
    public class RoleDto
    {
        public string Id { get; set; }

        [DisplayName("Rol Adı")]
        [Required(ErrorMessage ="{0} alanı boş bırakılamaz")]
        public string Name { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string Description { get; set; }
    }
}
