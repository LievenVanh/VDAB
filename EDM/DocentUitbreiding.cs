using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM
{
    public partial class Docent
    {
        public string Naam
        {
            get { return Voornaam + ' ' + Familienaam; }

        }

        public void Opslag(decimal bedrag)
        {
            Wedde += bedrag;
        }
    }
}
