using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using uuregistration.Models;

namespace uuregistration.Repositories
{
    public interface IUurRegistratieRepository
    {
        IQueryable<UurRegistratie> AllUren { get; }
        IQueryable<UurRegistratieDetails> AllDetails(int uurRegistratieId);
        IQueryable<UurRegistratie> AllIncluding(params Expression<Func<UurRegistratie, object>>[] includeProperties);
        UurRegistratie Find(int id);
        UurRegistratieDetails FindDetails(int id);
        void InsertOrUpdate(UurRegistratie uurRegistratie);
        void InsertOrUpdate(UurRegistratieDetails uurRegistratieDetails);
        void DeleteUurRegistratie(int id);
        void DeleteUurRegistratieDetail(int id);
        void Save();
        void Dispose();
    }
}
