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

        public UnitOfWork()
        {
            context = new UuregistratieContext();
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

        public KlantenRepository KlantenRepository
        {
            get
            {
                if (klantenRepository == null) { klantenRepository = new KlantenRepository(context); }
                return klantenRepository;
            }
            private set { klantenRepository = value; }
        }
        public void SaveChanges()
        { context.SaveChanges(); }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}