using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uuregistration.Models
{
    public class Gebruiker
    {
        public enum Rol { USER, DEPARTEMENTADMINISTRATOR, ADMINISTRATOR }
        public int GebruikerId { get; set; } //pk
        public string Login { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
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