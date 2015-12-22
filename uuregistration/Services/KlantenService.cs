using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uuregistration.Models;
using uuregistration.Repositories;

namespace uuregistration.Services
{
    public class KlantenService : IKlantenService, IDisposable
    {
        private UnitOfWork uow;
        public KlantenService()
        {
            uow = new UnitOfWork();
        }
        public void Delete(int id)
        {
            uow.KlantenRepository.Delete(id);
        }
        public void Dispose()
        {
            uow.Dispose();
        }
        public List<Klant> GetAllKlanten()
        {
            return uow.KlantenRepository.All.ToList<Klant>();
        }

        public Klant GetKlant(int id)
        {
            return uow.KlantenRepository.Find(id);
        }

        public void InsertOrUpdate(Klant klant)
        {
            uow.KlantenRepository.InsertOrUpdate(klant);
            uow.SaveChanges();
        }

        public void SaveChanges()
        {
            uow.SaveChanges();
        }
    }
}