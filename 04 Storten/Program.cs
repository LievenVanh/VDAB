using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Storten
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef rekeningnummer om op te storten (xxx-xxxxxxx-xx): ");
            string rekeningnummer = Console.ReadLine();
            using (var bankEntities = new BankEntities())
            {
                var rekening = bankEntities.Rekeningen.Find(rekeningnummer);
                if (rekening != null)
                {
                    Console.WriteLine("Geef te storten bedrag in: ");
                    decimal bedrag;
                    decimal.TryParse(Console.ReadLine(), out bedrag);
                    rekening.Storten(bedrag);
                    bankEntities.SaveChanges();
                    Console.WriteLine(bedrag+"EUR gestort op rekeningnummer "+rekening.RekeningNr);
                }

                else
                {
                    Console.WriteLine("Rekening niet gevonden");
                }
            }
        }
    }
}
