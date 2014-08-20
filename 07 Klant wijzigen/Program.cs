using System;
using System.Collections.Generic;
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
            catch (Exception)
            {
                Console.WriteLine("Tik een getal");
            }
            
            
        }

        void KlantWijzigen(int klantNr)
        {
            using (var bankEnitites = new BankEntities())
            {
                var klant = bankEnitites.Klanten.Find(klantNr);
            }
        }
    }

}
