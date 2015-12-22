using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uuregistration.Models
{
    public class Update
    {
        public enum Type {GREATION, UPDATE}
        public int Id { get; set; }
        public Gebruiker Author { get; set; }
        public DateTime UpdateTijd { get; set; }
        public Type UpdateType { get; set; }
        public string UpdateOmschrijving { get; set; }

        public Update(){}

        public Update(Gebruiker author, Type type, string omschrijving)
        {

        }

    }
}