using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uuregistration.Models;

namespace uuregistration.Services
{
    public interface IUurRegistratieDetailsService
    {
        List<UurRegistratieDetails> GetAllDetailsForUurRegistratie();
        UurRegistratieDetails GetUurRegistratieDetails(int id);
        void InsertOrUpdateDetails(UurRegistratieDetails uurRegistratieDetails);
        void SaveChanges();
        void DeleteUurRegistratieDetails(int id);
    }
}
