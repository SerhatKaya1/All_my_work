using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid02_SingleResponsibility.After
{
    public static class Actions
    {
        public static int Sum(int number1, int number2)
        {
            if (!Validations.IsValid(number1, number2))
            {
                throw new Exception("Girilen sayılardan biri ya da hepsi kriterlere uygun değildir.");
            }
            return number1 + number2;
        }
    }
}
