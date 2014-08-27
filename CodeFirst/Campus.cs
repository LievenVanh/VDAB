using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    [Table("Campussen")]
    public class Campus
    {
        [Column("Id")]
        public int CampusId { get; set; }
        [Column("Campusnaam")]
        public string Naam { get; set; }
        public Adres Adres { get; set; }
        public ICollection<Instructeur> Instructeurs { get; set; }

    }
}
