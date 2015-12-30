using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using uuregistration.Models;

namespace uuregistration.Repositories
{
    public interface IFacturenRepository
    {
        IQueryable<Factuur> AllFacturen { get; }
        IQueryable<FactuurDetails> AllFactuurDEtails(int factuurId);
        IQueryable<Factuur> AllIncluding(params Expression<Func<Factuur, object>>[] includeProperties);
        Factuur Find(int id);
        FactuurDetails FindDetails(int id);
        void InsertOrUpdate(Factuur factuur);
        void InsertOrUpdate(FactuurDetails factuurDetails);
        void DeleteFactuur(int id);
        void DeleteFactuurDetails(int id);
        void Save();
        void Dispose();
    }
}
