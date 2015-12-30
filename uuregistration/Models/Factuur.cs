using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace uuregistration.Models
{
    public class Factuur
    {
        public int Id { get; set; }
        [Display(Name = "FactuurJaar", ResourceType = typeof(Resources.Resource))]
        public int FactuurJaar { get; set; }
        public int FactuurNummer { get; set; }
        public virtual Klant Klant { get; set; }
        public DateTime FactuurDatum { get; set; }
        [DataType(DataType.Date)]
        public DateTime BeginPeriode { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndPeriode { get; set; }
        public float Totaal { get; set; }
        public List<FactuurDetails> DetailGegevens { get; set; }
        public List<Update> UpdateRecords { get; set; }

        public Factuur()
        {
            FactuurDatum = DateTime.Now;
            DetailGegevens = new List<FactuurDetails>();
        }
    }
}