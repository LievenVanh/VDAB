using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    [Table("Landen")]
    public class Land
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Landcode { get; set; }
        public string Naam { get; set; }
    }
}
