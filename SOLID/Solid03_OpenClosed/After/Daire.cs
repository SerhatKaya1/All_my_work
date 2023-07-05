using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid03_OpenClosed.After
{
    public class Daire : Sekil
    {
        public int Yaricap { get; set; }

        public Daire(int yaricap)
        {
            Yaricap = yaricap;
        }

        public override double AlanHesapla()
        {
            return Math.PI * Math.Pow(Yaricap, 2);
        }
    }
}
