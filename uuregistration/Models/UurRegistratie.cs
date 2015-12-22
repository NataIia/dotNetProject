using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uuregistration.Models
{
    public class UurRegistratie
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Omschrijving { get; set; }
        public virtual Klant Klant { get; set; }
        public List<Update> UpdateRecords { get; set; }
    }
}