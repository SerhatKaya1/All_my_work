using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid03_OpenClosed.After
{
    public class Hesapla
    {
        public double AlanlariTopla(Sekil[] sekiller)
        {
            double alanToplami = 0;
            foreach (var sekil in sekiller)
            {
                alanToplami += sekil.AlanHesapla();
            }
            return alanToplami;
        }
    }
}
