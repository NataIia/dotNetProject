using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uuregistration.Models;
using uuregistration.Repositories;

namespace uuregistration.Services
{
    public class UurRegistratieService : IUurRegistratieService, IDisposable
    {
        private UnitOfWork uow;
        public UurRegistratieService()
        {
            uow = new UnitOfWork();
        }
        public void DeleteUurRegistratie(int id)
        {
            uow.UurRegistratieRepository.DeleteUurRegistratie(id);
        }

        public void DeleteUurRegistratieDetails(int id)
        {
            uow.UurRegistratieRepository.DeleteUurRegistratieDetail(id);
        }

        public void Dispose()
        {
            uow.Dispose();
        }

        public List<UurRegistratie> GetAllUurRegistraties()
        {
            return uow.UurRegistratieRepository.AllUren.ToList<UurRegistratie>();
        }

        public List<UurRegistratieDetails> GetDetailsForUurRegistratie(int uurRegistratieId)
        {
            return uow.UurRegistratieRepository.AllDetails(uurRegistratieId).ToList<UurRegistratieDetails>();
        }

        public UurRegistratie GetUurRegistratie(int id)
        {
            return uow.UurRegistratieRepository.Find(id);
        }

        public UurRegistratieDetails GetUurRegistratieDetails(int id)
        {
            return uow.UurRegistratieRepository.FindDetails(id);
        }

        public void InsertOrUpdate(UurRegistratie uurRegistratie)
        {
            uow.UurRegistratieRepository.InsertOrUpdate(uurRegistratie);
            uow.SaveChanges();
        }

        public void InsertOrUpdateDetails(UurRegistratieDetails uurRegistratieDetails)
        {
            uow.UurRegistratieRepository.InsertOrUpdate(uurRegistratieDetails);
            uow.SaveChanges();
        }

        public void SaveChanges()
        {
            uow.SaveChanges();
        }
    }
}