using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekTarifiApp.Data.Abstract
{
    public interface IRepository<T> //<T> Entity karşılığı: Dışarıdan entity parametresi gönderebilmem gerekiyor.
    {
        Task<T> GetByIdAsync(int id);  //Id'ye göre entity getirecek- Güncelleme veya silme işlemi yapmka istediğimde id ile ilgili alana taşıma işlemi yapmam gerekiyor. İd ye göre veri getirilecek bir method tanımlamak gerek.
        Task<List<T>> GetAllAsync();   //İlgili tüm kayıtları getirecek
        Task CreateAsync(T entity);    //yeni kayıt yaratacak
        void Update(T entity);          //kayıt güncelleyecek
        void Delete(T entity);            //kayıt silecek
    }
}
/*T türünde entity parametresi alacaksın diyoruz.*/

/*
 Task ne demek C#?
NET içerisinde asenkron programlama deyince async/await dışında akla gelen şeylerden biri de Task tipi. 
Task tipi en basit anlatımla asenkron operasyonu temsil eden bir tip. 
Bu tipi kullanarak asenkron operasyonla ilgili tüm detaylara erişebilmemiz mümkün
*/
