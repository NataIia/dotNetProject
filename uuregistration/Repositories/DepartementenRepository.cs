using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uuregistration.DataAccessLayer;
using uuregistration.Models;

namespace uuregistration.Repositories
{
    public class DepartementenRepository : IDepartementenRepository
    {
        UuregistratieContext context;

        public DepartementenRepository()
        {
            context = new UuregistratieContext();
        }

        public DepartementenRepository(UuregistratieContext context)
        {
            this.context = context;
        }
        public IQueryable<Departement> AllDepartementen
        {
            get
            {
                return context.Departements;
            }
        }
    }
}