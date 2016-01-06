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
        private DateTime startTijd;
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        private DateTime eindTijd;
        [DataType(DataType.Date)]
        public DateTime EindDate { get; set; }
        public string TypeWerk { get; set; }
        public Boolean TeFactureren { get; set; }
        public List<Update> UpdateRecords { get; set; }
        public int? UurRegistratieId { get; set; }
        public virtual UurRegistratie UurRegistratie { get; set; }
        [DataType(DataType.Time)]
        public DateTime StartTijd //opdracht: tot op een kwartier nauwkeurig
        {
            get { return startTijd;  }
            set
            {
                DateTime dt = value;
                dt = dt.AddSeconds(-dt.Second);
                dt = dt.AddMinutes(-(dt.Minute % 15));
                startTijd =  dt;
            }
        }
        [DataType(DataType.Time)]
        public DateTime EindTijd //opdracht: tot op een kwartier nauwkeurig
        {
            get { return eindTijd; }
            set
            {
                DateTime dt = value;
                dt = dt.AddSeconds(-dt.Second);
                dt = dt.AddMinutes(-(dt.Minute % 15));
                eindTijd = dt;
            }
        }
    }
}