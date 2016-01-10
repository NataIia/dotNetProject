using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uuregistration.DataAccessLayer;
using uuregistration.Models;

namespace uuregistration.Services
{
    public static class Helper
    {
        public static List<ApplicationUser> GetAllUsers()
        {
            GebruikersService gebruikerService = new GebruikersService();
            return gebruikerService.GetAllGebruikers();
        }

        public static ApplicationUser GetUserByName(string name, UuregistratieContext context)
        {
            ApplicationUser applicationUser = null;
            foreach (ApplicationUser user in context.Gebruikers)
            {
                if (user.Login == name) applicationUser = user;
            }
            return applicationUser;
        }
    }
}