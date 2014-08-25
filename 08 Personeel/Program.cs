using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _08_Personeel
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Personeel> personeel = new List<Personeel>();
            using (var bankEntities = new BankEntities())
            {
                personeel = (from persoon in bankEntities.Personeel
                    where persoon.ManagerNr.Equals(null)
                    select persoon).ToList();
            }
            new Program().Afbeelden(personeel,0);
            Console.ReadLine();
        }

        private void Afbeelden(List<Personeel> personeel, int insprong )
        {
            foreach (var persoon in personeel)
            {
                Console.Write(new string('\t',insprong));
                
                Console.WriteLine(persoon.Voornaam);
                using (var bankEntities = new BankEntities())
                {
                    var query = (from ondergeschikten in bankEntities.Personeel
                                 where ondergeschikten.ManagerNr == persoon.PersoneelsNr
                                 select ondergeschikten).ToList();
                    this.Afbeelden(query, insprong+1);
                }
            }
            
        }
    }
}
