using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uuregistration.DataAccessLayer;
using uuregistration.Models;
using uuregistration.Repositories;

namespace uuregistration.Services
{
    public class FacturenService : IFacturenService, IDisposable
    {
        private UnitOfWork uow;
        public FacturenService()
        {
            uow = new UnitOfWork();
        }

        public UuregistratieContext Context
        {
            get { return uow.Context; }
        }

        public void DeleteFactuur(int id)
        {
            uow.FacturenRepository.DeleteFactuur(id);
        }

        public void DeleteFactuurDetails(int id)
        {
            uow.FacturenRepository.DeleteFactuurDetails(id);
        }

        public void Dispose()
        {
            uow.Dispose();
        }

        public List<Factuur> GetAllFacturen()
        {
            return uow.FacturenRepository.AllFacturen.ToList<Factuur>();
        }

        public List<Factuur> GetAllFacturenByDepartement(int departementId)
        {
            List<Factuur> facturen = new List<Factuur>();
            foreach (Factuur f in this.GetAllFacturen())
            {
                if (f.Klant.Gebruiker.DepartementId == departementId) facturen.Add(f);
            }
            return facturen;
        }

        public List<FactuurDetails> GetDetailsForFactuur(int factuurId)
        {
            return uow.FacturenRepository.AllFactuurDEtails(factuurId).ToList<FactuurDetails>();
        }

        public Factuur GetFactuur(int id)
        {
            return uow.FacturenRepository.Find(id);
        }

        public FactuurDetails GetFactuurDetails(int id)
        {
            return uow.FacturenRepository.FindDetails(id);
        }

        public void InsertOrUpdate(Factuur factuur)
        {
            uow.FacturenRepository.InsertOrUpdate(factuur);
            uow.SaveChanges();
        }

        public void InsertOrUpdateDetails(FactuurDetails factuurDetails)
        {
            uow.FacturenRepository.InsertOrUpdate(factuurDetails);
        }

        public void SaveChanges()
        {
            uow.SaveChanges();
        }
    }
}