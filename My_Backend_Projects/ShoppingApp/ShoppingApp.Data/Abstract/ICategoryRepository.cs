using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        //Category'e özgü memberlar burada olacak.(property, field, method...)ü
        //Örneğin aşağıdakiler gibi:
        Category GetByIdWithProducts();
    }
}
