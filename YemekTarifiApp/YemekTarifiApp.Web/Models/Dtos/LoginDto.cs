using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace YemekTarifiApp.Web.Models.Dtos
{
	public class LoginDto
	{
		[DisplayName("Kullanıcı Adı")]
		[Required(ErrorMessage = "{0} boş bırakılmamalı.")]
		public string UserName { get; set; }

		[DisplayName("Şifre")]
		[Required(ErrorMessage = "{0} boş bırakılmamalı.")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public string ReturnUrl { get; set; }
	}
}
