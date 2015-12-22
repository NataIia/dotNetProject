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
    public class GebruikersRepository : IGebruikersRepository
    {
        UuregistratieContext context;

        public GebruikersRepository()
        {
            context = new UuregistratieContext();
        }
        public GebruikersRepository(UuregistratieContext context)
        {
            this.context = context;
        }
        public IQueryable<Gebruiker> All
        {
            get
            {
                return context.Gebruikers;
            }
        }

        public IQueryable<Gebruiker> AllIncluding(params Expression<Func<Gebruiker, object>>[] includeProperties)
        {
            IQueryable<Gebruiker> query = context.Gebruikers;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Delete(int id)
        {
            var gebruiker = context.Gebruikers.Find(id);
            context.Gebruikers.Remove(gebruiker);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Gebruiker Find(int id)
        {
            return context.Gebruikers.Find(id);
        }

        public void InsertOrUpdate(Gebruiker gebruiker)
        {

            if (gebruiker.Id == default(int))
            {
//                gebruiker.UpdateRecords.Add(new Update(new Gebruiker(), Update.Type.GREATION, ""));
                context.Gebruikers.Add(gebruiker);
            } //new gebruiker
            else
            {
 //               gebruiker.UpdateRecords.Add(new Update(new Gebruiker(), Update.Type.UPDATE, ""));
                context.Entry(gebruiker).State = EntityState.Modified;
            } //existing gebruiker
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}