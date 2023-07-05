using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid05_InterfaceSegregation.Before
{
    public class Otomobil : IOtomobil
    {
        public int KapiSayisi { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int UretimYili { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int IletimHiziniGetir()
        {
            throw new NotImplementedException();
        }

        public string IletimTipiniGetir()
        {
            throw new NotImplementedException();
        }

        public int KapiSayisiniGetir()
        {
            throw new NotImplementedException();
        }

        public double MotorGucunuGetir()
        {
            throw new NotImplementedException();
        }

        public string YakitTipiniGetir()
        {
            throw new NotImplementedException();
        }
    }
}
