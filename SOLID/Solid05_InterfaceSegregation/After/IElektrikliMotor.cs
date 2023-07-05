using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid05_InterfaceSegregation.After
{
    public interface IElektrikliMotor
    {
        public string BataryaTipiniGetir();
        public decimal VoltajDegeriniGetir();
    }
}
