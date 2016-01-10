using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uuregistration.Models;

namespace uuregistration.Services
{
    /// <summary>
    /// De IGebruikersService is the interface injected in the controllers. 
    /// This is additional layer used in complex Views/Controller for different
    /// representation of data
    /// </summary>
    public interface IGebruikersService
    {
        List<ApplicationUser> GetAllGebruikers();
        ApplicationUser GetGebruiker(String id);
        int GetDepartementId(string gebruikerNaam);
        void InsertOrUpdate(ApplicationUser gebruiker);
        void SaveChanges();
        void Delete(int id);
    }
}
