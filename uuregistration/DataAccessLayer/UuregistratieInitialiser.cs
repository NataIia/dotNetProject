using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            this.AddUserAndRoles(context);

            /*It isn't necessary to call the SaveChanges method after each group of entities, as is done here, but doing that helps
             you locate the source of a problem if an exception occurs while the code is writing to the database. */
            context.SaveChanges();


            base.Seed(context);

            context.SaveChanges();

        }

        bool AddUserAndRoles(UuregistratieContext context)
        {
            bool success = false;

            Departement d1 = new Departement { departementCode = "d1", departementOmschrijving = "departement1" };
            Departement d2 = new Departement { departementCode = "d2", departementOmschrijving = "departement2" };

            var departementen = new List<Departement> { d1, d2 };

            departementen.ForEach(d => context.Departements.Add(d));

            context.SaveChanges();

            var idManager = new IdentityManager();
            success = idManager.CreateRole("Administrator", context);
            if (!success == true) return success;

            success = idManager.CreateRole("DepartementAdministrator", context);
            if (!success == true) return success;

            success = idManager.CreateRole("Gebruiker", context);
            if (!success) return success;

            context.SaveChanges();


            var newUserAdmin = new ApplicationUser()
            {
                Voornaam = "Natalia",
                Achternaam = "Dyubankova",
                Email = "administrator@groept.be",
                UserName = "administrator@groept.be",
                Login = "NataliaDyubankovaAdmin", 
                Departement = d1                
            };

            // careful here - password should fill the requirements
            success = idManager.CreateUser(newUserAdmin, "GroeptT@2015", context);
            if (!success) return success;

            success = idManager.AddUserToRole(newUserAdmin.Id, "Administrator", context);
            if (!success) return success;

            var newUserDAdmin = new ApplicationUser()
            {
                Voornaam = "Natalia",
                Achternaam = "Dyubankova",
                Email = "departementadministrator@groept.be",
                UserName = "departementadministrator@groept.be",
                Login = "NataliaDyubankovaDAdmin",
                Departement = d1
            };

            success = idManager.CreateUser(newUserDAdmin, "GroeptT@2015", context);
            if (!success) return success;

            success = idManager.AddUserToRole(newUserDAdmin.Id, "DepartementAdministrator", context);
            if (!success) return success;

            var newUserGebruiker = new ApplicationUser()
            {
                Voornaam = "Natalia",
                Achternaam = "Dyubankova",
                Email = "user@groept.be",
                UserName = "user@groept.be",
                Login = "NataliaDyubankovaUser",
                Departement = d2
            };

            success = idManager.CreateUser(newUserGebruiker, "GroeptT@2015", context);
            if (!success) return success;

            success = idManager.AddUserToRole(newUserGebruiker.Id, "Gebruiker", context);
            if (!success) return success;

            Klant k1 = new Klant { Ondernemingsnummer = "1", Bedrijfsnaam = "Bedrijf 1", Adres = "Straat1 1", Postcode = "1111", Plaats = "City1" , Gebruiker = newUserAdmin };
            Klant k2 = new Klant { Ondernemingsnummer = "2", Bedrijfsnaam = "Bedrijf 2", Adres = "Straat1 2", Postcode = "2222", Plaats = "City2", Gebruiker = newUserGebruiker };
            Klant k3 = new Klant { Ondernemingsnummer = "3", Bedrijfsnaam = "Bedrijf 3", Adres = "Straat1 3", Postcode = "3333", Plaats = "City3", Gebruiker = newUserDAdmin };
            Klant k4 = new Klant { Ondernemingsnummer = "4", Bedrijfsnaam = "Bedrijf 4", Adres = "Straat1 4", Postcode = "4444", Plaats = "City4", Gebruiker = newUserGebruiker };
            Klant k5 = new Klant { Ondernemingsnummer = "5", Bedrijfsnaam = "Bedrijf 5", Adres = "Straat1 5", Postcode = "5555", Plaats = "City5", Gebruiker = newUserDAdmin };

            var klanten = new List<Klant>
            { k1, k2, k3, k4, k5            };
            klanten.ForEach(k => context.Klanten.Add(k));
            context.SaveChanges();


            UurRegistratieDetails urd1 = new UurRegistratieDetails { StartDate = new DateTime(2014, 1, 18, 15, 02, 38), StartTijd = new DateTime(2014, 1, 18, 15, 59, 45), EindDate = new DateTime(2014, 2, 18, 15, 13, 45), EindTijd = new DateTime(2014, 2, 18, 15, 59, 45), TeFactureren = true };
            UurRegistratieDetails urd2 = new UurRegistratieDetails { StartDate = new DateTime(2015, 1, 18, 15, 26, 45), StartTijd = new DateTime(2015, 1, 18, 15, 59, 45), EindDate = new DateTime(2015, 2, 18, 15, 38, 45), EindTijd = new DateTime(2015, 2, 18, 15, 59, 45), TeFactureren = false };

            var uurRegistratieDetails = new List<UurRegistratieDetails>
            { urd1, urd2 };

            uurRegistratieDetails.ForEach(ud => context.UurRegistratieDetails.Add(ud));
            context.SaveChanges();

            UurRegistratie ur1 = new UurRegistratie { Titel = "uur test1", Omschrijving = "uur omsch test1", Details = new List<UurRegistratieDetails>(), Klant = k1 };
            UurRegistratie ur2 = new UurRegistratie { Titel = "uur test2", Omschrijving = "uur omsch test2", Details = new List<UurRegistratieDetails>(), Klant = k2 };
            ur1.Details.Add(urd1);
            ur1.Details.Add(urd2);
            var uurRedistraries = new List<UurRegistratie>
            { ur1, ur2 };

            uurRedistraries.ForEach(u => context.UurenRegistratie.Add(u));
            context.SaveChanges();

            return success;
        }
    }
}