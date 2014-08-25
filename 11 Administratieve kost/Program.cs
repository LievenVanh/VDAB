using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Administratieve_kost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef de administratieve kost in: ");
            decimal adminKost;
            if (decimal.TryParse(Console.ReadLine(), out adminKost))
            {
                using (var bankEntities = new BankEntities())
                {
                    bankEntities.AdministratieveKost(adminKost);
                    Console.WriteLine("Administratieve kost toegepast");
                }
            }
            else
            {
                Console.WriteLine("Geef een geldig bedrag in");
            }
            Console.ReadLine();
        }
    }
}
