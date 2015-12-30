using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using uuregistration.DataAccessLayer;
using uuregistration.Models;

namespace uuregistration.Repositories
{
    public class FacturenRepository : IFacturenRepository
    {
        UuregistratieContext context;
        public FacturenRepository()
        {
            context = new UuregistratieContext();
        }
        public FacturenRepository(UuregistratieContext context)
        {
            this.context = context;
        }

        public IQueryable<Factuur> AllFacturen
        {
            get
            {
                return context.Facturen;
            }
        }
        public IQueryable<FactuurDetails> AllFactuurDEtails(int factuurId)
        {
            return context.FactuurDetails.AsQueryable().Where(fd => fd.Factuur.Id == factuurId);
        }

        public IQueryable<Factuur> AllIncluding(params Expression<Func<Factuur, object>>[] includeProperties)
        {
            IQueryable<Factuur> query = context.Facturen;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void DeleteFactuur(int id)
        {
            var factuur = context.Facturen.Find(id);
            context.Facturen.Remove(factuur);
        }

        public void DeleteFactuurDetails(int id)
        {
            var factuurDetail = context.FactuurDetails.Find(id);
            context.FactuurDetails.Remove(factuurDetail);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Factuur Find(int id)
        {
            return context.Facturen.Find(id);
        }

        public FactuurDetails FindDetails(int id)
        {
            return context.FactuurDetails.Find(id);
        }

        public void InsertOrUpdate(FactuurDetails factuurDetails)
        {
            if (factuurDetails.Id == default(int))
            {
                //                factuurDetails.UpdateRecords.Add(new Update(null, Update.Type.GREATION, "new factuurDetails"));
                context.FactuurDetails.Add(factuurDetails);
            } //new factuurDetails
            else
            {
                //               factuurDetails.UpdateRecords.Add(new Update(null, Update.Type.UPDATE, "update factuurDetails" + factuurDetails.Id));
                context.Entry(factuurDetails).State = EntityState.Modified;
            } //existing factuurDetails
        }

        public void InsertOrUpdate(Factuur factuur)
        {
            Klant k = new Klant();
            foreach (Klant kl in context.Klanten)
                if (kl.Bedrijfsnaam == factuur.Klant.Bedrijfsnaam)
                {
                    k = kl;
                };

            if (factuur.Id == default(int))
            {
                factuur.FactuurDatum = DateTime.Now;
                factuur.FactuurJaar = factuur.FactuurDatum.Year;
                //factuur.UpdateRecords.Add(new Update(null, Update.Type.GREATION, "new factuur"));
                context.Facturen.Add(factuur);
            } //new factuur
            else
            {
                //               factuur.UpdateRecords.Add(new Update(null, Update.Type.UPDATE, "update factuur" + factuur.Id));
                context.Entry(factuur).State = EntityState.Modified;
            } //existing factuurDetails
            factuur.FactuurDatum = DateTime.Now;
            factuur.FactuurJaar = factuur.FactuurDatum.Year;
            factuur.Klant = k;
            foreach (UurRegistratie ur in context.UurenRegistratie)
            {
                var test = ur.Details;
                if (ur.Klant == factuur.Klant)
                {
                    foreach (UurRegistratieDetails urd in ur.Details)
                    {
                        if (urd.StartTijd > factuur.BeginPeriode && urd.EindTijd <= factuur.EndPeriode)
                        { factuur.DetailGegevens.Add(new FactuurDetails(ur)); }
                    }
                }

            }
            context.Entry(factuur).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}