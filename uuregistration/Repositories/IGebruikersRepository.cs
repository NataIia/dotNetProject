using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using uuregistration.Models;

namespace uuregistration.Repositories
{
    public interface IGebruikersRepository
    {
        IQueryable<ApplicationUser> All { get; }
        IQueryable<ApplicationUser> AllIncluding(params Expression<Func<ApplicationUser, object>>[] includeProperties);
        ApplicationUser Find(String id);
        void InsertOrUpdate(ApplicationUser person);
        void Delete(int id);
        void Save();
        void Dispose();
    }
}
