using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uuregistration.Models;
using uuregistration.Repositories;

namespace uuregistration.Services
{
    public class UurRegistratieDetailsService : IUurRegistratieDetailsService, IDisposable
    {
        private UnitOfWork uow;
        public UurRegistratieDetailsService()
        {
            uow = new UnitOfWork();
        }
        public void DeleteUurRegistratieDetails(int id)
        {
            uow.UurRegistratieDetailsRepository.DeleteUurRegistratieDetail(id);
        }

        public void Dispose()
        {
            uow.Dispose();
        }

        public List<UurRegistratieDetails> GetAllDetailsForUurRegistratie()
        {
            return uow.UurRegistratieDetailsRepository.AllDetails.ToList<UurRegistratieDetails>();
        }

        public UurRegistratieDetails GetUurRegistratieDetails(int id)
        {
            return uow.UurRegistratieDetailsRepository.FindDetails(id);
        }

        public void InsertOrUpdateDetails(UurRegistratieDetails uurRegistratieDetails)
        {
            uow.UurRegistratieDetailsRepository.InsertOrUpdate(uurRegistratieDetails);
        }

        public void SaveChanges()
        {
            uow.SaveChanges();
        }
    }
}