using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekTarifiApp.Core
{
    public static class Jobs
    {
        public static string InitUrl(string url)
        {
           
            #region SorunluKarakterlerDüzeltiliyor
            url = url.Replace("I", "i");
            url = url.Replace("İ", "i");
            url = url.Replace("ı", "i");
            #endregion
            #region KüçükHarfeDönüştürülüyor
            url = url.ToLower();
            #endregion
            #region TürkçeKarakterlerDönüştürülüyor
            url = url.Replace("ö", "o");
            url = url.Replace("ü", "u");
            url = url.Replace("ş", "s");
            url = url.Replace("ç", "c");
            url = url.Replace("ğ", "g");
            #endregion
            #region BoşluklarTireİleDeğiştiriliyor
            url = url.Replace(" ", "-");
            #endregion
            #region SorunluKarakterlerKaldırılıyor
            url = url.Replace(".", "");
            url = url.Replace("/", "");
            url = url.Replace("\"", "");
            url = url.Replace("'", "");
            url = url.Replace("(", "");
            url = url.Replace(")", "");
            url = url.Replace("[", "");
            url = url.Replace("]", "");
            url = url.Replace("{", "");
            url = url.Replace("}", "");
            #endregion
            return url;

        }
        public static string UploadImage(IFormFile image)
        {
            var extension = Path.GetExtension(image.FileName);
            var rondomName = $"{Guid.NewGuid()}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/YemekTarifiImages", rondomName);
            using (var stream = new FileStream(path,FileMode.Create))
            {
                image.CopyTo(stream);
            }
            return rondomName;

        }
        public static string CreateMessage(string title, string message, string alertType)
        {
            var msg = new AlertMessage
            {
                Title = title,
                Message = message,
                AlertType = alertType
            };
            return JsonConvert.SerializeObject(msg);
        }
    }
}
