using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Zichtrekening_toevoegen
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            int keuze = 0;
            using (var bankEntities = new BankEntities())
            {
                var query = from klant in bankEntities.Klanten
                            orderby klant.Voornaam
                            select klant;
                foreach (var klant in query)
                {
                    Console.WriteLine(klant.KlantNr+": "+klant.Voornaam);
                }
                Console.Write("KlantNr: ");
                if(int.TryParse(Console.ReadLine(), out keuze))
                {
                    var gekozenKlant = bankEntities.Klanten.Find(keuze);
                    if (gekozenKlant != null)
                    {
                        Console.Write("Geef nieuw rekeningnummer in: ");
                        var nieuweRekening = new Rekening {Saldo = 0, RekeningNr = Console.ReadLine(), Soort = "Z"};
                        gekozenKlant.Rekeningen.Add(nieuweRekening);
                        bankEntities.SaveChanges();
                        Console.WriteLine("Rekening toegevoegd");
                    }
                    else
                    {
                        Console.WriteLine("Klant niet gevonden");

                        

                    }
                }
                else
                {
                    Console.WriteLine("Tik een getal");
                }

            }
            Console.ReadLine();
        }
    }
}
