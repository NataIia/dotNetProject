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
        public IQueryable<ApplicationUser> All
        {
            get
            {
                return context.Gebruikers;
            }
        }

        public IQueryable<ApplicationUser> AllIncluding(params Expression<Func<ApplicationUser, object>>[] includeProperties)
        {
            IQueryable<ApplicationUser> query = context.Gebruikers;
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

        public ApplicationUser Find(String id)
        {
            return context.Gebruikers.Find(id);
        }

        public void InsertOrUpdate(ApplicationUser gebruiker)
        {
            Boolean exist = false;

            foreach (ApplicationUser g in context.Gebruikers.ToList<ApplicationUser>())
            {
                if (g.Id == gebruiker.Id)
                {
                    exist = true;
                }
            }

            if (!exist)
            {
//                gebruiker.UpdateRecords.Add(new Update(null, Update.Type.GREATION, "new gebruiker"));
                context.Gebruikers.Add(gebruiker);
            } //new gebruiker
            else
            {
//                gebruiker.UpdateRecords.Add(new Update(null, Update.Type.UPDATE, "update gebruiker" + gebruiker.Id));
                context.Entry(gebruiker).State = EntityState.Modified;
            } //existing gebruiker
        }

        public void Save()
        {
            //The member with identity ' ' does not exist in the metadata collection.\r\nParameter name: identity error
            //context.Configuration.ValidateOnSaveEnabled = false;
            context.SaveChanges();
        }
    }
}