using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace uuregistration.Models
{
    public class UurRegistratieDetails
    {
        public int UurRegistratieDetailsId { get; set; }
        [DataType(DataType.Time)]
        public DateTime StartTijd { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EindTijd { get; set; }
        public string TypeWerk { get; set; }
        public Boolean TeFactureren { get; set; }
        public List<Update> UpdateRecords { get; set; }
        public int? UurRegistratieId { get; set; }
        public virtual UurRegistratie UurRegistratie { get; set; }
    }
}