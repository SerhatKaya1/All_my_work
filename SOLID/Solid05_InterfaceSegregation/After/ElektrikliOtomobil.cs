using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid05_InterfaceSegregation.After
{
    public class ElektrikliOtomobil : IOtomobilOrtak, IElektrikliMotor
    {
        public string BataryaTipiniGetir()
        {
            throw new NotImplementedException();
        }

        public int KapiSayisiniGetir()
        {
            throw new NotImplementedException();
        }

        public int UretimYiliniGetir()
        {
            throw new NotImplementedException();
        }

        public decimal VoltajDegeriniGetir()
        {
            throw new NotImplementedException();
        }
    }
}
