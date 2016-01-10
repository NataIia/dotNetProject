using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uuregistration.Models;
using uuregistration.Repositories;

namespace uuregistration.Services
{
    public class GebruikersService : IGebruikersService, IDisposable
    {
        private UnitOfWork uow;
        public GebruikersService()
        {
            uow = new UnitOfWork();
        }
        public void Delete(int id)
        {
            uow.GebruikerRepository.Delete(id);
        }

        public void Dispose()
        {
            uow.Dispose();
        }

        public List<ApplicationUser> GetAllGebruikers()
        {
            return uow.GebruikerRepository.All.ToList<ApplicationUser>();
        }

        public ApplicationUser GetGebruiker(String id)
        {
            return uow.GebruikerRepository.Find(id);
        }

        public void InsertOrUpdate(ApplicationUser gebruiker)
        {
            uow.GebruikerRepository.InsertOrUpdate(gebruiker);
            uow.SaveChanges();
        }

        public void SaveChanges()
        {
            uow.SaveChanges();
        }
        public int GetDepartementId(string gebruikerNaam)
        {
            ApplicationUser applicationUser = null;
            foreach (ApplicationUser user in uow.GebruikerRepository.All.ToList<ApplicationUser>())
            {
                if (user.Login == gebruikerNaam) applicationUser = user;
            }
            return applicationUser.DepartementId ?? default(int);
        }
    }
}