using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    [ComplexType]
    public class Adres
    {
        [Column("Straat")]
        public string Straat { get; set; }
        [Column("Huisnummer")]
        public string Huisnummer { get; set; }
        [Column("Woonplaats")]
        public string Woonplaats { get; set; }
        [Column("Postcode")]
        public string Postcode { get; set; }
    }
}
