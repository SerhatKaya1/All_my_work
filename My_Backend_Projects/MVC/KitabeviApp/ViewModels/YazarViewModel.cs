using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KitabeviApp.ViewModels
{
    public class YazarViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Lütfen adı boş bırakmayınız!")]
        [StringLength(30,ErrorMessage ="Lütfen 30 karakterden daha fazla girmeyiniz!")]
        [Display(Name ="Yazar Adı Soyadı:", Prompt ="Yazar ad soyadı...")]
        public string Ad { get; set; }
        [Required(ErrorMessage ="Lütfen doğum yılını yazınız!")]
        [Display(Name ="Yazar Doğum Yılı: ", Prompt ="2000...")]
        public int? DogumYili { get; set; }
        public char Cinsiyet { get; set; }
    }
}