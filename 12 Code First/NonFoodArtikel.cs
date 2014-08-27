using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Code_First
{
    [Table("NonFoodArtikels")]
    public class NonFoodArtikel:Artikel
    {
        public int Garantie { get; set; }
    }
}
