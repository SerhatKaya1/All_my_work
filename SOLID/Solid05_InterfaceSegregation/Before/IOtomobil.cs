using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid05_InterfaceSegregation.Before
{
    public interface IOtomobil
    {
        public int KapiSayisi { get; set; }
        public int UretimYili { get; set; }
        public int KapiSayisiniGetir();
        public double MotorGucunuGetir();
        public string YakitTipiniGetir();
        public string IletimTipiniGetir();
        public int IletimHiziniGetir();
    }
}
