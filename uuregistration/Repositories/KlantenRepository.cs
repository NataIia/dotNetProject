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
    public class KlantenRepository : IKlantenRepository
    {
        UuregistratieContext context;
        public KlantenRepository()
        {
            context = new UuregistratieContext();
        }
        public KlantenRepository(UuregistratieContext context)
        {
            this.context = context;
        }
        public IQueryable<Klant> All
        {
            get
            {
                return context.Klanten;
            }
        }

        public IQueryable<Klant> AllIncluding(params Expression<Func<Klant, object>>[] includeProperties)
        {
            IQueryable<Klant> query = context.Klanten;
            foreach(var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Delete(int id)
        {
            var klant = context.Klanten.Find(id);
            context.Klanten.Remove(klant);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Klant Find(int id)
        {
            return context.Klanten.Find(id);
        }

        public void InsertOrUpdate(Klant person)
        {
            if (person.KlantId == default(int))
            { context.Klanten.Add(person); } //new gebruiker
            else { context.Entry(person).State = EntityState.Modified; } //existing gebruiker

        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}