using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uuregistration.Models;

namespace uuregistration.ViewModels
{
    public class UurRegistratieDetailsViewModel
    {
        public List<UurRegistratieDetails> UurRegistratieDetails { get; set; }
        public UurRegistratieDetails UurRegistratieDetail { get; set; }
    }
}