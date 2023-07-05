using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Web.Areas.Admin.Models.Dtos
{
    public class UserAddDto
    {
        public UserDto UserDto { get; set; }
        public List<RoleDto> Roles { get; set; }

        [DisplayName("Rol")]
        [Required(ErrorMessage ="En az bir {0} seçilmelidir.")]
        public IList<string> SelectedRoles { get; set; }
    }
}
