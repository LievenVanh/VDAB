using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Code_First
{
    public class ArtikelContext:DbContext
    {
        public DbSet<Leverancier> Leveranciers { get; set; }
        public DbSet<Artikelgroep> Artikelgroepen { get; set; }
        
        public DbSet<NonFoodArtikel> NonFoodArtikels { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artikel>().HasMany(i=>i.Leveranciers).WithMany(v=>v.Artikels).Map(c=>c.ToTable("LeveranciersArtikels").MapLeftKey("LeverancierId").MapRightKey("ArtikelId"));
        }
    }
}
