using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Klant_verwijderen
{
    class Program
    {
        static void Main(string[] args)
        {
            int klantnummer;
            Console.Write("Geef klantnummer om te verwijderen: ");
            using (var bankEntities = new BankEntities())
            {
                if (int.TryParse(Console.ReadLine(), out klantnummer))
                {
                    var klant = bankEntities.Klanten.Find(klantnummer);
                    if (klant != null)
                    {
                        Console.WriteLine(klant.Voornaam);
                        if (klant.Rekeningen.Count == 0)
                        {
                            bankEntities.Klanten.Remove(klant);
                            bankEntities.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("Kan klant niet verwijderen, klant heeft nog rekeningen");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Klant niet gevonden");
                    }
                }
                else
                {
                    Console.WriteLine("Geef een geldig getal in");
                }
            }
            Console.ReadLine();
        }
    }
}
