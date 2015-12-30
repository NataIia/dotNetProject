using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uuregistration.DataAccessLayer;

namespace uuregistration.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private UuregistratieContext context;
        private GebruikersRepository gebruikerRepository;
        private KlantenRepository klantenRepository;
        private UurRegistratieRepository uurRegistratieRepository;
        private FacturenRepository facturenRepository;

        public UnitOfWork()
        {
            context = new UuregistratieContext();
        }
        public KlantenRepository KlantenRepository
        {
            get
            {
                if (klantenRepository == null) { klantenRepository = new KlantenRepository(context); }
                return klantenRepository;
            }
            private set { klantenRepository = value; }
        }
        public GebruikersRepository GebruikerRepository
        {
            get
            {
                if (gebruikerRepository == null) { gebruikerRepository = new GebruikersRepository(context); }
                return gebruikerRepository;
            }
            private set { gebruikerRepository = value; }
        }

        public UurRegistratieRepository UurRegistratieRepository
        {
            get
            {
                if (uurRegistratieRepository == null) { uurRegistratieRepository = new UurRegistratieRepository(context); }
                return uurRegistratieRepository;
            }
            private set { uurRegistratieRepository = value; }
        }
        public FacturenRepository FacturenRepository
        {
            get
            {
                if (facturenRepository == null) { facturenRepository = new FacturenRepository(context); }
                return facturenRepository;
            }
            private set { facturenRepository = value; }
        }
        public void SaveChanges()
        { context.SaveChanges(); }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}