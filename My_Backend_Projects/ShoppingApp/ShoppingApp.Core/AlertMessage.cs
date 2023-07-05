using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Core
{
    //Uygulama içinde çeşitli durumlarda ihtiyaç duyacağımız/duyduğumuz uyarı mesajları için kullanılacak bir tip.
    public class AlertMessage
    {
        public string Title { get; set; }//Uyarı mesajının başlığı
        public string Message { get; set; }//Uyarı mesajı
        public string AlertType { get; set; }//Uyarı mesajının tipi, görünümü
    }
}
