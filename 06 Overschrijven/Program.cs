using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace _06_Overschrijven
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Geef het rekeningnummer waarvan overgeschreven wordt: ");
                string vanRek = Console.ReadLine();
                Console.Write("Geef het doelrekeningnummer: ");
                string naarRek = Console.ReadLine();
                Console.Write("Geef het bedrag: ");
                var bedrag = decimal.Parse(Console.ReadLine());
                if(!(bedrag<Decimal.Zero))
                    new Program().Overschrijven(vanRek, naarRek, bedrag);
                else
                    Console.WriteLine("Geef een positief getal in");
            }
            catch (FormatException)
            {
                Console.WriteLine("geef een geldig bedrag in");
            }

        }

        void Overschrijven(string vanRekeningNr, string naarRekeningNr, decimal bedrag)
        {
            var transactionOptions = new TransactionOptions {IsolationLevel = IsolationLevel.RepeatableRead};
            using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
            {
                using (var bankEntities = new BankEntities())
                {
                    var vanRek = bankEntities.Rekeningen.Find(vanRekeningNr);
                    var naarRek = bankEntities.Rekeningen.Find(naarRekeningNr);
                    if (vanRek != null)
                    {
                        if (naarRek != null)
                        {
                            try 
                            {
                                vanRek.Overschrijven(naarRek, bedrag);
                                bankEntities.SaveChanges();
                                transactionScope.Complete();
                            }
                            catch (SaldoOntoereikendException)
                            {
                                Console.WriteLine("Saldo ontoereikend");
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Naar rekeningnummer niet gevonden");
                        }
                        
                        
                    }
                    else
                    {
                        Console.WriteLine("Van rekeningnummer niet gevonden");
                    }
                    
                    
                    

                }
            }
            

        }
    }
}
