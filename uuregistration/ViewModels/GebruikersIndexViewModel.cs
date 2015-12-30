using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uuregistration.Models;

namespace uuregistration.ViewModels
{
    public class GebruikersIndexViewModel
    {
        public List<Gebruiker> Gebruikers { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public List<Departement> Departementen { get; set; }
        public Departement Departement { get; set; }
    }
}