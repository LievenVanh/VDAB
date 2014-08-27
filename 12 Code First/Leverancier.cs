using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Code_First
{
    public class Leverancier
    {
        public int LeverancierId { get; set; }
        public string Naam { get; set; }
        public ICollection<Artikel> Artikels { get; set; } 
    }
}
