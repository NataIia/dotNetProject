using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uuregistration.Models;

namespace uuregistration.ViewModels
{
    public class UurRegistratieViewModel
    {
        public List<UurRegistratieDetails> Details { get; set; }
        public UurRegistratieDetails Detail { get; set; }
        public UurRegistratie UurRegistratie { get; set; }
        public List<UurRegistratie> UurRegistraties { get; set; }
    }
}