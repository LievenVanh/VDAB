using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace _12_Code_First
{
    [Table("Artikels")]
    public abstract class Artikel
    {
        public int ArtikelId { get; set; }
        public string Naam { get; set; }
        public ICollection<Leverancier> Leveranciers { get; set; }
        public int? ArtikelGroepId { get; set; }
    }
}
