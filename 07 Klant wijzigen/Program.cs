using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Klant_wijzigen
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Geef klantnummer: ");
            try
            {
                int klantNr = int.Parse(Console.ReadLine());
                new Program().KlantWijzigen(klantNr);
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine("Data werd reeds gewijzigd door een ander programma");
            }
            catch (FormatException)
            {
                Console.WriteLine("Tik een getal");
            }
            Console.ReadLine();

        }

        void KlantWijzigen(int klantNr)
        {
            using (var bankEnitites = new BankEntities())
            {
                var klant = bankEnitites.Klanten.Find(klantNr);
                if (klant != null)
                {
                    Console.WriteLine("Geef nieuwe voornaam voor klant {0}: {1}",klant.KlantNr, klant.Voornaam);
                    klant.Voornaam = Console.ReadLine();
                    bankEnitites.SaveChanges();
                    Console.WriteLine("Aanpassingen met succes doorgevoerd");
                }
                else
                    Console.WriteLine("Klant niet gevonden");
            }
        }
    }

}
