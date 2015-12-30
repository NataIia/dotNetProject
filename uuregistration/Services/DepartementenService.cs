using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uuregistration.Models;
using uuregistration.Repositories;

namespace uuregistration.Services
{
    public class DepartementenService : IDepartementenService, IDisposable
    {
        private UnitOfWork uow;
        public DepartementenService()
        {
            uow = new UnitOfWork();
        }

        public void Dispose()
        {
            uow.Dispose();
        }

        public List<Departement> GetAllDepartementen()
        {
            return uow.DepartementenRepository.AllDepartementen.ToList<Departement>();
        }
    }
}