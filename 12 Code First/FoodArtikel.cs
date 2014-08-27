using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Code_First
{
    [Table("FoodArtikels")]
    public class FoodArtikel:Artikel
    {
        public int Houdbaarheid { get; set; }
    }
}
