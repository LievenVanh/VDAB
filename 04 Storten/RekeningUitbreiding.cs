using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Storten
{
    public partial class Rekening
    {
        public void Storten(decimal bedrag)
        {
            Saldo += bedrag;
        }
    }
}
