using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _10_Totale_saldo_per_klant
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Totale saldo per klant:");
            using (var bankEntities = new BankEntities())
            {
                var query = from saldoKlant in bankEntities.TotaleSaldoPerKlant
                    orderby saldoKlant.Voornaam
                    select saldoKlant;
                foreach (var saldoKlant in query)
                {
                    Console.WriteLine("{0}: {1}",saldoKlant.Voornaam, saldoKlant.TotaleSaldo);
                }
            }
            Console.ReadLine();
        }
    }
}
