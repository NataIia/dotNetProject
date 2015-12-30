using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uuregistration.Models
{
    public class UurRegistratie
    {
        public int UurRegistratieId { get; set; }
        public string Titel { get; set; }
        public string Omschrijving { get; set; }
        public int KlantId { get; set; }
        public virtual Klant Klant { get; set; }
        public virtual List<UurRegistratieDetails> Details { get; set; }
        public virtual List<FactuurDetails> FactuurDetails { get; set; }
        public virtual List<Update> UpdateRecords { get; set; }

    }
}