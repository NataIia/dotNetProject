using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using uuregistration.Repositories;
using uuregistration.DataAccessLayer;

namespace uuregistration.Models
{
    public class ApplicationUser : IdentityUser
    {
        //===== gebruiker properties from opdracht
        public string Login { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public int? DepartementId { get; set; }
        public virtual Departement Departement { get; set; }
        public virtual ICollection<Klant> Klanten { get; set; }
        public virtual ICollection<Update> UpdateRecords { get; set; }
        public ApplicationUser()
        {
            UpdateRecords = new List<Update>();
        }
        //===== end gebruiker properties from opdracht

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("UuregistratieContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
             return new ApplicationDbContext();
        }
    }

    public class IdentityManager
    {
        public bool RoleExists(string name, UuregistratieContext context)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            return rm.RoleExists(name);
        }


        public bool CreateRole(string name, UuregistratieContext context)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            var idResult = rm.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }


        public bool CreateUser(ApplicationUser user, string password, UuregistratieContext context)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var idResult = um.Create(user, password);
            return idResult.Succeeded;
        }


        public bool AddUserToRole(string userId, string roleName, UuregistratieContext context)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var idResult = um.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }


        public void ClearUserRoles(string userId, UuregistratieContext context)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = um.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();
            currentRoles.AddRange(user.Roles);
            foreach (var role in currentRoles)
            {
                um.RemoveFromRole(userId, role.RoleId);
//                um.RemoveFromRole(userId, role.Role.Name);
            }
        }
    }
}
