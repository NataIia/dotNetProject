using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using uuregistration.DataAccessLayer;
using uuregistration.Models;

namespace uuregistration.Repositories
{
    public class UurRegistratieRepository : IUurRegistratieRepository
    {
        UuregistratieContext context;
        public UurRegistratieRepository()
        {
            context = new UuregistratieContext();
        }
        public UurRegistratieRepository(UuregistratieContext context)
        {
            this.context = context;
        }

/*        public IQueryable<UurRegistratieDetails> AllDetails(int uurRegistratieId)
        {
           IQueryable<UurRegistratieDetails> allDetails = context.UurRegistratieDetails;
            IQueryable<UurRegistratieDetails> query = context.UurRegistratieDetails;
            foreach (var item in allDetails)
            {
                query = query.Include(includeProperty);
            } 
            return context.UurRegistratieDetails.;
        } */

        public IQueryable<UurRegistratie> AllUren
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IQueryable<UurRegistratieDetails> AllDetails(int uurRegistratieId)
        {
            return context.UurRegistratieDetails.AsQueryable().Where(urd => urd.UurRegistratie.Id == uurRegistratieId);
        }

        public IQueryable<UurRegistratie> AllIncluding(params Expression<Func<UurRegistratie, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void DeleteUurRegistratie(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteUurRegistratieDetail(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public UurRegistratie Find(int id)
        {
            throw new NotImplementedException();
        }

        public UurRegistratieDetails FindDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(UurRegistratieDetails uurRegistratieDetails)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(UurRegistratie uurRegistratie)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}