using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid05_InterfaceSegregation.After
{
    public class YanmaliOtomobil : IOtomobilOrtak, IYanmaliMotor
    {
        public int KapiSayisiniGetir()
        {
            throw new NotImplementedException();
        }

        public double MotorGucunuGetir()
        {
            throw new NotImplementedException();
        }

        public int UretimYiliniGetir()
        {
            throw new NotImplementedException();
        }

        public string YakitTipiniGetir()
        {
            throw new NotImplementedException();
        }
    }
}
