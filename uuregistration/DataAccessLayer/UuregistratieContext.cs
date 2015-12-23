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
    {
        public UuregistratieContext() : base() { }

        public DbSet<Gebruiker> Gebruikers { get; set;}
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<UurRegistratie> UurenRegistratie { get; set; }
        public DbSet<Factuur> Facturen { get; set; }
        //prevents table names from being pluralized
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
           {
               modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           }

        public System.Data.Entity.DbSet<uuregistration.Models.UurRegistratieDetails> UurRegistratieDetails { get; set; }
    }
}