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

            var klanten = new List<Klant>
            {
                new Klant { Ondernemingsnummer = "1", Bedrijfsnaam = "Bedrijf 1", Adres = "Straat1 1", Postcode = "1111", Plaats = "City1" },
                new Klant { Ondernemingsnummer = "2", Bedrijfsnaam = "Bedrijf 2", Adres = "Straat1 2", Postcode = "2222", Plaats = "City2" },
                new Klant { Ondernemingsnummer = "3", Bedrijfsnaam = "Bedrijf 3", Adres = "Straat1 3", Postcode = "3333", Plaats = "City3" },
                new Klant { Ondernemingsnummer = "4", Bedrijfsnaam = "Bedrijf 4", Adres = "Straat1 4", Postcode = "4444", Plaats = "City4" },
                new Klant { Ondernemingsnummer = "5", Bedrijfsnaam = "Bedrijf 5", Adres = "Straat1 5", Postcode = "5555", Plaats = "City5" },

            };
            klanten.ForEach(k => context.Klanten.Add(k));
            context.SaveChanges();
        }
    }
}