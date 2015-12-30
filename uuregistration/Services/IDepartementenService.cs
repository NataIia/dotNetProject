using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uuregistration.Models;

namespace uuregistration.Services
{
    public interface IDepartementenService
    {
        List<Departement> GetAllDepartementen();
    }
}
