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
            Departement d1 = new Departement { departementCode = "d1", departementOmschrijving = "departement1" };
            Departement d2 = new Departement { departementCode = "d2", departementOmschrijving = "departement2" };

            var departementen = new List<Departement> { d1, d2 };

            departementen.ForEach(d => context.Departements.Add(d));
            /*It isn't necessary to call the SaveChanges method after each group of entities, as is done here, but doing that helps
             you locate the source of a problem if an exception occurs while the code is writing to the database. */
            context.SaveChanges();

            //creating a UserManger from ASP.NET Identity system which will let us do operations on the
            //User such as Create, List, Edit and Verify the user.You can think of the UserManager as 
            //being analogus to SQLMembershpProvider in ASP.NET 2.0
            var UserManager = new UserManager<Gebruiker>(new UserStore<Gebruiker>(context));

            //creating a RoleManager from ASP.NET Identity system which lets us operate on Roles.
            //You can think of the RoleManager as being analogus to SQLRoleMembershpProvider in ASP.NET 2.0
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));


            string name = "Admin";
            string password = "123456";

            //Create Role Admin if it does not exist
            if (!RoleManager.RoleExists(name))
            {
                  var roleresult = RoleManager.Create(new IdentityRole(name));
             }
               
           //Create User=Admin with password=123456
            var user = new Gebruiker();
            user.Login  = name;
            user.UserName = user.Login;
            var adminresult = UserManager.Create(user, password);
            context.Gebruikers.Add(user);

            //Add User Admin to Role Admin
            if (adminresult.Succeeded)
            {
                Console.WriteLine("here");
                var result = UserManager.AddToRole(user.Id, name);
             }

            base.Seed(context);

        //var gebruikers = new List<Gebruiker>
        //{
        //    new Gebruiker { Login = "test1", Voornaam = "t1", Achternaam = "e1", Email = "@1", Departement = d1},
        //    new Gebruiker { Login = "test2", Voornaam = "t2", Achternaam = "e2", Email = "@2", Departement = d2},
        //    new Gebruiker { Login = "test3", Voornaam = "t3", Achternaam = "e3", Email = "@3", Departement = d1},
        //    new Gebruiker { Login = "test4", Voornaam = "t4", Achternaam = "e4", Email = "@4", Departement = d2},
        //    new Gebruiker { Login = "test5", Voornaam = "t5", Achternaam = "e5", Email = "@5", Departement = d1},
        //};
        //            gebruikers.ForEach(g => context.Gebruikers.Add(g));

            context.SaveChanges();

            Klant k1 = new Klant { Ondernemingsnummer = "1", Bedrijfsnaam = "Bedrijf 1", Adres = "Straat1 1", Postcode = "1111", Plaats = "City1" };
            Klant k2 = new Klant { Ondernemingsnummer = "2", Bedrijfsnaam = "Bedrijf 2", Adres = "Straat1 2", Postcode = "2222", Plaats = "City2" };
            Klant k3 = new Klant { Ondernemingsnummer = "3", Bedrijfsnaam = "Bedrijf 3", Adres = "Straat1 3", Postcode = "3333", Plaats = "City3" };
            Klant k4 = new Klant { Ondernemingsnummer = "4", Bedrijfsnaam = "Bedrijf 4", Adres = "Straat1 4", Postcode = "4444", Plaats = "City4" };
            Klant k5 = new Klant { Ondernemingsnummer = "5", Bedrijfsnaam = "Bedrijf 5", Adres = "Straat1 5", Postcode = "5555", Plaats = "City5" };

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

/*            ApplicationUser user = new ApplicationUser { Email = "departementadministrator@groept.be", PasswordHash = "" };
            ApplicationUser dadmin = new ApplicationUser { Email = "2", PasswordHash = "2"};
            ApplicationUser admin = new ApplicationUser { Email = "3", PasswordHash = "3"};

            var users = new List<ApplicationUser> { user, dadmin, admin };

            users.ForEach(u => context.ApplicationUsers.Add(u));
            context.SaveChanges(); */

        }
    }
}