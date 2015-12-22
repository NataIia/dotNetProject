using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uuregistration.Models
{
    public class Klant
    {
        public int Id { get; set; }
        public string Ondernemingsnummer { get; set; }

        public string Bedrijfsnaam { get; set; }
        public string Adres { get; set; }
        public string Postcode { get; set; }
        public string Plaats { get; set; }
        public virtual Gebruiker Gebruiker { get; set; }
        public List<Update> UpdateRecords { get; set; }
    }
}