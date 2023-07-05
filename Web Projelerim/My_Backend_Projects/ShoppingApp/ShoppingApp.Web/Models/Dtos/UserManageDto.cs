using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Web.Models.Dtos
{
    public class UserManageDto
    {
        public string Id { get; set; }
        [DisplayName("Ad")]
        [Required(ErrorMessage ="{0} alanı zorunludur.")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string LastName { get; set; }
        [DisplayName("Cinsiyet")]
        public string Gender { get; set; }

        [DisplayName("Doğum Tarihi")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string UserName { get; set; }
        public List<SelectListItem> GenderSelectList { get; set; }
    }
}
