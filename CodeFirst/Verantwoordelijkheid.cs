using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    [Table("Verantwoordelijkheden")]
    public class Verantwoordelijkheid
    {
        
        public int VerantwoordelijkheidId { get; set; }
        public string Naam { get; set; }
        public ICollection<Instructeur> Instructeurs { get; set; } 
    }
}
