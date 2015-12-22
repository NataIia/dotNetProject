using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using uuregistration.Models;

namespace uuregistration.DataAccessLayer
{
    public class UuregistratieInitialiser : DropCreateDatabaseIfModelChanges<UuregistratieContext>
    {
        protected override void Seed(UuregistratieContext context)
        {
            var gebruikers = new List<Gebruiker>
            {
                new Gebruiker { Login = "test1", Voornaam = "t1", Achternaam = "e1", Email = "@1"},
                new Gebruiker { Login = "test2", Voornaam = "t2", Achternaam = "e2", Email = "@2"},
                new Gebruiker { Login = "test3", Voornaam = "t3", Achternaam = "e3", Email = "@3"},
                new Gebruiker { Login = "test4", Voornaam = "t4", Achternaam = "e4", Email = "@4"},
                new Gebruiker { Login = "test5", Voornaam = "t5", Achternaam = "e5", Email = "@5"},
            };
            gebruikers.ForEach(g => context.Gebruikers.Add(g));
            /*It isn't necessary to call the SaveChanges method after each group of entities, as is done here, but doing that helps
              you locate the source of a problem if an exception occurs while the code is writing to the database. */
            context.SaveChanges();
        }
    }
}