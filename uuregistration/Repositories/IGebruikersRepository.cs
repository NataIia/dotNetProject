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
        IQueryable<Gebruiker> All { get; }
        IQueryable<Gebruiker> AllIncluding(params Expression<Func<Gebruiker, object>>[] includeProperties);
        Gebruiker Find(int id);
        void InsertOrUpdate(Gebruiker person);
        void Delete(int id);
        void Save();
        void Dispose();
    }
}
