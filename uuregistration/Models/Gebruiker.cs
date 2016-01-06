using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;


namespace uuregistration.Models
{
    public class Gebruiker : IdentityUser
    {
        public enum Rol { USER, DEPARTEMENTADMINISTRATOR, ADMINISTRATOR }
//        public int GebruikerId { get; set; } //pk
        public string Login { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
//        public string Email { get; set; } from ApplicationUser
        public int? DepartementId { get; set; }
        public Rol GebruikerRol { get; set; }
        public virtual Departement Departement { get; set; }
//        public virtual ICollection<Departement> Departementen { get; set; }
        public virtual ICollection<Klant> Klanten { get; set; }
        public virtual ICollection<Update> UpdateRecords { get; set; }
        public Gebruiker()
        {
            UpdateRecords = new List<Update>();
        }
    }
}