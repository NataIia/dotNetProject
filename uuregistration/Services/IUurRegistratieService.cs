using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uuregistration.Models;

namespace uuregistration.Services
{
    public interface IUurRegistratieService
    {
        List<UurRegistratie> GetAllUurRegistraties();
        List<UurRegistratieDetails> GetDetailsForUurRegistratie(int uurRegistratieId);
        UurRegistratie GetUurRegistratie(int id);
        UurRegistratieDetails GetUurRegistratieDetails(int id);
        void InsertOrUpdate(UurRegistratie uurRegistratie);
        void InsertOrUpdateDetails(UurRegistratieDetails uurRegistratieDetails);
        void SaveChanges();
        void DeleteUurRegistratie(int id);
        void DeleteUurRegistratieDetails(int id);
    }
}
