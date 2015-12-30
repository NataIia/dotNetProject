using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using uuregistration.Services;
using Microsoft.AspNet.Identity;
using uuregistration.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using uuregistration.Controllers;

namespace uuregistration
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IGebruikersService, GebruikersService>();
            container.RegisterType<IKlantenService, KlantenService>();
            container.RegisterType<IUurRegistratieService, UurRegistratieService>();
            container.RegisterType<IFacturenService, FacturenService>();
            container.RegisterType<IDepartementenService, DepartementenService>();
            container.RegisterType<AccountController>(new InjectionConstructor()); //solves the error The current type, Microsoft.AspNet.Identity.IUserStore`1[uuregistration.Models.ApplicationUser], is an interface and cannot be constructed. Are you missing a type mapping?
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}