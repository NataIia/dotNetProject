using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using uuregistration.Models;

namespace uuregistration.Repositories
{
    interface IKlantenRepository
    {
        IQueryable<Klant> All { get; }
        IQueryable<Klant> AllIncluding(params Expression<Func<Klant, object>>[] includeProperties);
        Klant Find(int id);
        void InsertOrUpdate(Klant person);
        void Delete(int id);
        void Save();
        void Dispose();
    }
}
