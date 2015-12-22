using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uuregistration.Models
{
    public class FactuurDetails
    {
        public int Id { get; set; }
        public int HoofdlijnId { get; set; }
        public string Omschrijving { get; set; }
        public List<DateTime> TijdGegevens { get; set; }
        public float LijnNetto { get; set; }
        public List<Update> UpdateRecords { get; set; }
    }
}