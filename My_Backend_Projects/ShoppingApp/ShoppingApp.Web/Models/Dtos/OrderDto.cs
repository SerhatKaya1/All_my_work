using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Web.Models.Dtos
{
    public class OrderDto
    {
        [DisplayName("Ad")]
        [Required(ErrorMessage ="{0} alanı boş bırakılmamalıdır.")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string LastName { get; set; }

        [DisplayName("Adres")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string Address { get; set; }

        [DisplayName("Şehir")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string City { get; set; }

        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Kartın Üzerindeki Ad Soyad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string CardName { get; set; }

        [DisplayName("Kart Numarası")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string CardNumber { get; set; }

        [DisplayName("Geçerlilik Tarihi Ay")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string ExpirationMonth { get; set; }

        [DisplayName("Geçerlilik Tarihi Yıl")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string ExpirationYear { get; set;}

        [DisplayName("Kartın Arka Yüzündeki 3 Haneli Güvenlik Numarası")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalıdır.")]
        public string Cvc { get; set; }
        public CardDto CardDto { get; set; }
    }
}
