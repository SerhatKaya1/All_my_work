using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid02_SingleResponsibility.After
{
    public static class Validations
    {
        public static bool IsValid(int a, int b)
        {
            return a < 0 || b < 0 ? false : true;
        }
    }
}
