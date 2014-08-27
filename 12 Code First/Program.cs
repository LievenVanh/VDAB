using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Code_First
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ArtikelContext>());
            using (var context = new ArtikelContext())
            {
                var artikelGroep = new Artikelgroep() {Naam = "testGroep"};
                ICollection<Artikel> testArtikels = new Collection<Artikel>();
                var artikel = new NonFoodArtikel() {Naam = "test"};
                testArtikels.Add(artikel);
                artikelGroep.Artikels = testArtikels;
                context.Artikelgroepen.Add(artikelGroep);
                context.NonFoodArtikels.Add(artikel);
                context.SaveChanges();
                artikel = context.NonFoodArtikels.Find(1);
                Console.WriteLine(artikel.ArtikelId);
            }
            Console.ReadLine();
        }
        
    }
}
