using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uuregistration.Models;

namespace uuregistration.Services
{
    interface IKlantenService
    {
        List<Klant> GetAllKlanten();
        Klant GetKlant(int id);
        void InsertOrUpdate(Klant klant);
        void SaveChanges();
        void Delete(int id);
    }
}
