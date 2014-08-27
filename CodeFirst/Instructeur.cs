using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Instructeur
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public Adres Adres { get; set; }
        [Column("Maandwedde")]
        public decimal Wedde { get; set; }
        [Column("Datum in dienst",TypeName = "date")]
        public DateTime InDienst { get; set; }
        [Column("Rijbewijs B")]
        public bool? HeeftRijbewijs { get; set; }

        public virtual Campus Campus { get; set; }
        public int CampusId { get; set; }
        public ICollection<Verantwoordelijkheid> Verantwoordelijkheden { get; set; } 

        public void Opslag(decimal percentage)
        {
            Wedde *= (1M + percentage/100);
        }
    }
}
