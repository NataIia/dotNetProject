using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uuregistration.Models
{
    public class UurRegistratieDetails
    {
        public int Id { get; set; }
        public DateTime StartTijd { get; set; }
        public DateTime EindTijd { get; set; }
        public string TypeWerk { get; set; }
        public Boolean TeFactureren { get; set; }
        public List<Update> UpdateRecords { get; set; }
    }
}