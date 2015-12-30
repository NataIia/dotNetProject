﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uuregistration.Models;

namespace uuregistration.Services
{
    public interface IFacturenService
    {
        List<Factuur> GetAllFacturen();
        List<FactuurDetails> GetDetailsForFactuur(int factuurId);
        Factuur GetFactuur(int id);
        FactuurDetails GetFactuurDetails(int id);
        void InsertOrUpdate(Factuur factuur);
        void InsertOrUpdateDetails(FactuurDetails factuurDetails);
        void SaveChanges();
        void DeleteFactuur(int id);
        void DeleteFactuurDetails(int id);
    }
}