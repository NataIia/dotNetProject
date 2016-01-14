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
                return context.Users;
            }
        }

        public IQueryable<ApplicationUser> AllIncluding(params Expression<Func<ApplicationUser, object>>[] includeProperties)
        {
            IQueryable<ApplicationUser> query = context.Users;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Delete(int id)
        {
            var gebruiker = context.Users.Find(id);
            context.Users.Remove(gebruiker);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public ApplicationUser Find(String id)
        {
            return context.Users.Find(id);
        }

        public void InsertOrUpdate(ApplicationUser gebruiker)
        {
            Boolean exist = false;

            var idManager = new IdentityManager();

            foreach (ApplicationUser g in context.Users)
            {
                if (g.Id == gebruiker.Id)
                {
                    exist = true;
                }
            }

            if (!exist)
            {
                //gebruiker.UpdateRecords.Add(new Update(null, Update.Type.GREATION, "new gebruiker"));
                bool sucess1 = idManager.CreateUser(gebruiker, "Groept@2015", context);
                bool success2 = idManager.AddUserToRole(gebruiker.Id, "Gebruiker", context);
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