using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using uuregistration.Models;

namespace uuregistration.DataAccessLayer
{
    public class UuregistratieContext : DbContext
        //IdentityDbContext<ApplicationUser>
    {
        public UuregistratieContext() : base() { }

        public DbSet<Gebruiker> Gebruikers { get; set;}
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<UurRegistratie> UurenRegistratie { get; set; }
        public DbSet<Factuur> Facturen { get; set; }
        public DbSet<FactuurDetails> FactuurDetails {get; set;}
        public DbSet<UurRegistratieDetails> UurRegistratieDetails { get; set; }
/*                public DbSet<ApplicationUser> ApplicationUsers { get; set; }

                        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
                        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
                        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
                        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } */
        //prevents table names from being pluralized
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
           {
               modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           }
    }
}