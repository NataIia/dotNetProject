using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uuregistration.Models
{
    public class Tarief
    {
        public int Id { get; set; }
        public string TypeWerk { get; set; }
        public DateTime GeldigVanaf { get; set; }
        public float TariefWaarde { get; set; }
        public List<Update> UpdateRecords { get; set; }
    }
}