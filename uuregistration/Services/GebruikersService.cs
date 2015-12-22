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

        public List<Gebruiker> GetAllGebruikers()
        {
            return uow.GebruikerRepository.All.ToList<Gebruiker>();
        }

        public Gebruiker GetGebruiker(int id)
        {
            return uow.GebruikerRepository.Find(id);
        }

        public void InsertOrUpdate(Gebruiker gebruiker)
        {
            uow.GebruikerRepository.InsertOrUpdate(gebruiker);
            uow.SaveChanges();
        }

        public void SaveChanges()
        {
            uow.SaveChanges();
        }
    }
}