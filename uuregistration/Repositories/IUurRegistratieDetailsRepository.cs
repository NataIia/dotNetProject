using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using uuregistration.Models;

namespace uuregistration.Repositories
{
    interface IUurRegistratieDetailsRepository
    {
        IQueryable<UurRegistratieDetails> AllDetails { get; }
        IQueryable<UurRegistratieDetails> AllIncluding(params Expression<Func<UurRegistratieDetails, object>>[] includeProperties);
        UurRegistratieDetails FindDetails(int id);
        void InsertOrUpdate(UurRegistratieDetails uurRegistratieDetails);
        void DeleteUurRegistratieDetail(int id);
        void Save();
        void Dispose();
    }
}
