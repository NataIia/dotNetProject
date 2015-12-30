using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uuregistration.Models
{
    public class Departement
    {
        public int DepartementId { get; set; }
        public string departementCode { get; set; }
        public string departementOmschrijving { get; set; }
        public virtual ICollection<Gebruiker> Gebruikers { get; set; }
        public List<Update> UpdateRecords { get; set; }
    }
}