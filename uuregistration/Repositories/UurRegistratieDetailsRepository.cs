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
    public class UurRegistratieDetailsRepository : IUurRegistratieDetailsRepository
    {
        UuregistratieContext context;
        public UurRegistratieDetailsRepository()
        {
            context = new UuregistratieContext();
        }
        public UurRegistratieDetailsRepository(UuregistratieContext context)
        {
            this.context = context;
        }
        public IQueryable<UurRegistratieDetails> AllDetails
        {
            get
            {
                return context.UurRegistratieDetails;
            }
        }

        public IQueryable<UurRegistratieDetails> AllIncluding(params Expression<Func<UurRegistratieDetails, object>>[] includeProperties)
        {
            IQueryable<UurRegistratieDetails> query = context.UurRegistratieDetails;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void DeleteUurRegistratieDetail(int id)
        {
            var uurRegistratieDetails = context.UurRegistratieDetails.Find(id);
            context.UurRegistratieDetails.Remove(uurRegistratieDetails);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public UurRegistratieDetails FindDetails(int id)
        {
            return context.UurRegistratieDetails.Find(id);
        }

        public void InsertOrUpdate(UurRegistratieDetails uurRegistratieDetails)
        {
            if (uurRegistratieDetails.UurRegistratieDetailsId == default(int))
            {
                //                uurRegistratieDetails.UpdateRecords.Add(new Update(null, Update.Type.GREATION, "new uurRegistratieDetails"));
                context.UurRegistratieDetails.Add(uurRegistratieDetails);
            } //new uurRegistratieDetails
            else
            {
                //               uurRegistratieDetails.UpdateRecords.Add(new Update(null, Update.Type.UPDATE, "update uurRegistratieDetails" + uurRegistratieDetails.Id));
                context.Entry(uurRegistratieDetails).State = EntityState.Modified;
            } //existing uurRegistratieDetails
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}