using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace EDM
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Console.Write("Artikelnummer: ");
                var artikelNr = int.Parse(Console.ReadLine());
                Console.Write("Van magazijn nr: ");
                var vanMag = int.Parse(Console.ReadLine());
                Console.Write("Naar magazijn nr: ");
                var naarMag = int.Parse(Console.ReadLine());
                Console.Write("Aantal stuks: ");
                var aantal = int.Parse(Console.ReadLine());
                new Program().VoorraadTransfer(artikelNr, vanMag, naarMag, aantal);
            }
            catch (FormatException)
            {
                Console.WriteLine("Tik een getal");
            }
        }

        private void VoorraadTransfer(int artikelNr, int vanMagazijn, int naarMagazijn, int aantalStuks)
        {
            var transactionOptions = new TransactionOptions {IsolationLevel = IsolationLevel.RepeatableRead};
            using (var ts = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
            {
                using (var opleidingenEntities = new OpleidingenEntities())
                {
                    var vanVoorraad = opleidingenEntities.Voorraden.Find(vanMagazijn, artikelNr);
                    if (vanVoorraad != null)
                    {
                        if (vanVoorraad.AantalStuks >= aantalStuks)
                        {
                            vanVoorraad.AantalStuks -= aantalStuks;
                            var naarVoorraad = opleidingenEntities.Voorraden.Find(naarMagazijn, artikelNr);
                            if (naarVoorraad != null)
                            {
                                naarVoorraad.AantalStuks += aantalStuks;
                            }
                            else
                            {
                                naarVoorraad = new Voorraad()
                                {
                                    ArtikelNr = artikelNr,
                                    MagazijnNr = naarMagazijn,
                                    AantalStuks = aantalStuks
                                };
                                opleidingenEntities.Voorraden.Add(naarVoorraad);
                            }
                            opleidingenEntities.SaveChanges();
                            ts.Complete();
                        }
                        else
                        {
                            Console.WriteLine("Te weinig voorraad voor transfer");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Artikel niet gevonden in magazijn {0}", vanMagazijn);
                    }
                }
            }
        }

        private void VoorraadAanvulling(int artikelNr, int magazijnNr, int aantalStuks)
        {
            using (var opleidingenEntities = new OpleidingenEntities())
            {
                var artikel = opleidingenEntities.Voorraden.Find(artikelNr, magazijnNr);
                if (artikel != null)
                {
                    artikel.AantalStuks += aantalStuks;
                    try
                    {
                        opleidingenEntities.SaveChanges();
                    }
                    catch (DBConcurrencyException)
                    {
                        Console.WriteLine("Record werd gewijzigd door een andere applicatie");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Artikel {0} niet gevonden in magazijn {1}",artikelNr, magazijnNr);
                }
            }
        }
    }


}

