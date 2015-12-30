using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uuregistration.Models;

namespace uuregistration.Repositories
{
    interface IDepartementenRepository
    {
        IQueryable<Departement> AllDepartementen { get; }
    }
}
