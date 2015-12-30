using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uuregistration.Models;

namespace uuregistration.ViewModels
{
    public class FacturenIndexViewModel
    {
        public List<FactuurDetails> Details { get; set; }
        public FactuurDetails Detail { get; set; }
        public Factuur Factuur { get; set; }
        public List<Factuur> Facturen { get; set; }
        public List<Klant> Klanten { get; set; }
    }
}