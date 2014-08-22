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
            new Program().VoegBoekToe();
            Console.ReadLine();
            //try
            //{
            //    Console.Write("Artikelnummer: ");
            //    var artikelNr = int.Parse(Console.ReadLine());
            //    Console.Write("Van magazijn nr: ");
            //    var vanMag = int.Parse(Console.ReadLine());
            //    Console.Write("Naar magazijn nr: ");
            //    var naarMag = int.Parse(Console.ReadLine());
            //    Console.Write("Aantal stuks: ");
            //    var aantal = int.Parse(Console.ReadLine());
            //    new Program().VoorraadTransfer(artikelNr, vanMag, naarMag, aantal);
            //}
            //catch (FormatException)
            //{
            //    Console.WriteLine("Tik een getal");
            //}
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

        //private void ToonAlleBoekenMetCursussen()
        //{
        //    using (var opleidingenEntities = new OpleidingenEntities())
        //    {
        //        var query = from boek in opleidingenEntities.Boeken.Include("Cursussen")
        //                    orderby boek.Titel
        //                    select boek;
        //        foreach (var boek in query)
        //        {
        //            Console.WriteLine(boek.Titel);
        //            foreach (var cursus in boek.Cursussen)
        //            {
        //                Console.WriteLine("\t{0}", cursus.Naam);
        //            }
        //            Console.WriteLine();
        //        }
        //    }
        //}

        //private void ToonAlleCursussenMetBoeken()
        //{
        //    using (var opleidingenEntities = new OpleidingenEntities())
        //    {
        //        var query = from cursus in opleidingenEntities.Cursussen.Include("Boeken")
        //                    orderby cursus.Naam
        //                    select cursus;
        //        foreach (var cursus in query)
        //        {
        //            Console.WriteLine(cursus.Naam);
        //            foreach (var boek in cursus.Boeken)
        //            {
        //                Console.WriteLine("\t{0}", boek.Titel);
        //            }
        //            Console.WriteLine();
        //        }
        //    }
        //}

        //private void BoekToevoegen()
        //{
        //    using (var opleidingenEntities = new OpleidingenEntities())
        //    {
        //        var boek = new Boek { ISBNNr = "0-0788210-6-1", Titel = "Oracle Backup & Recovery Handbook" };
        //        var oracleCursus =
        //            (from cursus in opleidingenEntities.Cursussen where cursus.Naam == "Oracle" select cursus)
        //                .FirstOrDefault();
        //        if (oracleCursus != null)
        //        {
        //            oracleCursus.Boeken.Add(boek);
        //            opleidingenEntities.SaveChanges();
        //            Console.WriteLine("Boek toegevoegd");
        //        }
        //        else
        //        {
        //            Console.WriteLine("cursus Oracle niet gevonden");
        //        }
        //    }
        //}

        private void ToonAlleBoekenInCursus()
        {
            using (var opleidingenEntities = new OpleidingenEntities())
            {
                var query = from boekCursus in opleidingenEntities.BoekenCursussen.Include("Boek").Include("Cursus")
                    orderby boekCursus.Cursus.Naam, boekCursus.VolgNr
                    select boekCursus;
                var vorigCursusNr = 0;
                foreach (var boekCursus in query)
                {
                    if (boekCursus.Cursus.CursusNr != vorigCursusNr)
                    {
                        Console.WriteLine(boekCursus.Cursus.Naam);
                        vorigCursusNr = boekCursus.Cursus.CursusNr;
                    }
                    Console.WriteLine("\t{0}: {1}",boekCursus.VolgNr, boekCursus.Boek.Titel);

                }
            }
        }

        private void VoegBoekToe()
        {
            var nieuwBoek = new Boek {ISBNNr = "0-201-70431-5", Titel = "Modern C++ Design"};
            var transactionOptions = new TransactionOptions() {IsolationLevel = IsolationLevel.Serializable};
            using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
            {
                using (var opleidingenEntities = new OpleidingenEntities())
                {
                    var query = from cursus in opleidingenEntities.Cursussen.Include("BoekenCursussen")
                        where cursus.Naam == "C++"
                        select
                            new
                            {
                                Cursus = cursus,
                                HoogsteVolgNr = cursus.BoekenCursussen.Max(BoekCursus => BoekCursus.VolgNr)
                            };
                    var queryresult = query.FirstOrDefault();
                    if (queryresult != null)
                    {
                        opleidingenEntities.BoekenCursussen.Add(new BoekCursus()
                        {
                            Boek = nieuwBoek,
                            Cursus = queryresult.Cursus,
                            VolgNr = queryresult.HoogsteVolgNr + 1
                        });
                        opleidingenEntities.SaveChanges();
                    }
                    transactionScope.Complete();

                }
                
            }
        }
    }


}

