using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Overschrijven
{
    public partial class Rekening
    {
        public void Overschrijven(Rekening naarRekening, decimal bedrag)
        {
            if (Saldo<bedrag)
                throw new SaldoOntoereikendException();

            Saldo -= bedrag;
            naarRekening.Saldo += bedrag;
            

        }
    }
}
