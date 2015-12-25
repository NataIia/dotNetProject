using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                return context.UurenRegistratie;
            }
        }

        public IQueryable<UurRegistratieDetails> AllDetails(int uurRegistratieId)
        {
            return context.UurRegistratieDetails.AsQueryable().Where(urd => urd.UurRegistratie.Id == uurRegistratieId);
        }

        public IQueryable<UurRegistratie> AllIncluding(params Expression<Func<UurRegistratie, object>>[] includeProperties)
        {
            IQueryable<UurRegistratie> query = context.UurenRegistratie;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void DeleteUurRegistratie(int id)
        {
            var uurRegistratie = context.UurenRegistratie.Find(id);
            context.UurenRegistratie.Remove(uurRegistratie);
        }

        public void DeleteUurRegistratieDetail(int id)
        {
            var uurRegistratieDetails = context.UurRegistratieDetails.Find(id);
            context.UurRegistratieDetails.Remove(uurRegistratieDetails);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public UurRegistratie Find(int id)
        {
            return context.UurenRegistratie.Find(id);
        }

        public UurRegistratieDetails FindDetails(int id)
        {
            return context.UurRegistratieDetails.Find(id);
        }

        public void InsertOrUpdate(UurRegistratieDetails uurRegistratieDetails)
        {
            if (uurRegistratieDetails.Id == default(int))
            {
                uurRegistratieDetails.UpdateRecords.Add(new Update(null, Update.Type.GREATION, "new uurRegistratieDetails"));
                context.UurRegistratieDetails.Add(uurRegistratieDetails);
            } //new uurRegistratieDetails
            else
            {
                uurRegistratieDetails.UpdateRecords.Add(new Update(null, Update.Type.UPDATE, "update uurRegistratieDetails" + uurRegistratieDetails.Id));
                context.Entry(uurRegistratieDetails).State = EntityState.Modified;
            } //existing uurRegistratieDetails
        }

        public void InsertOrUpdate(UurRegistratie uurRegistratie)
        {
            if (uurRegistratie.Id == default(int))
            {
                uurRegistratie.UpdateRecords.Add(new Update(null, Update.Type.GREATION, "new uurRegistratie"));
                context.UurenRegistratie.Add(uurRegistratie);
            } //new uurRegistratie
            else
            {
                uurRegistratie.UpdateRecords.Add(new Update(null, Update.Type.UPDATE, "update uurRegistratie" + uurRegistratie.Id));
                context.Entry(uurRegistratie).State = EntityState.Modified;
            } //existing uurRegistratie
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}