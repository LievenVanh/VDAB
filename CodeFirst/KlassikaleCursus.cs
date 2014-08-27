using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    [Table("Klassikale Cursussen")]
    public class KlassikaleCursus: Cursus
    {
        public DateTime Van { get; set; }
        public DateTime Tot { get; set; }
    }
}
