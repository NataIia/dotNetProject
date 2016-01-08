using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using uuregistration.Models;

namespace uuregistration.DataAccessLayer
{
    public class UuregistratieContext : DbContext
        //IdentityDbContext<ApplicationUser>
    {
        public UuregistratieContext() : base() { }

        public DbSet<ApplicationUser> Gebruikers { get; set;}
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<UurRegistratie> UurenRegistratie { get; set; }
        public DbSet<Factuur> Facturen { get; set; }
        public DbSet<FactuurDetails> FactuurDetails {get; set;}
        public DbSet<UurRegistratieDetails> UurRegistratieDetails { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
           {
            //prevents table names from being pluralized
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            base.OnModelCreating(modelBuilder);

        }

        public System.Data.Entity.DbSet<uuregistration.Models.SelectRoleEditorViewModel> SelectRoleEditorViewModels { get; set; }
    }
}