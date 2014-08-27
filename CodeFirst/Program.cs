using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<VDABContext>());
            using (var context = new VDABContext())
            {
                var mentor = new Cursist() { Voornaam = "Bert", Familienaam = "Bibber" };
                var cursist = new Cursist(){Voornaam = "Jan", Familienaam = "Smit", Mentor = mentor};
                context.Cursisten.Add(mentor);
                context.Cursisten.Add(cursist);
                context.SaveChanges();

            }
            Console.ReadLine();
        }
    }
}
