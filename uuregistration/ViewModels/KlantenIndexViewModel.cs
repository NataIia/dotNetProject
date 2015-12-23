using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uuregistration.Models;

namespace uuregistration.ViewModels
{
    public class KlantenIndexViewModel
    {
        public List<Klant> Klanten { get; set; }
        public Klant Klant { get; set; }
    }
}