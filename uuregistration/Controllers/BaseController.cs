using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace uuregistration.Controllers
{
    public class BaseController : Controller
    {

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = null;

            HttpCookie cultureCookie = Request.Cookies["culture"]; //check if cookie exist
            if (cultureCookie != null)
            {
                cultureName = cultureCookie.Value;
            }
            else
            {
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ?
                        Request.UserLanguages[0] : // if nothing found, use this. this is returned by browser which exits
                        "nl-BE";
            }

            //eventueel controle op culturename toevoegen (legale waarde). Waarde komt uit cookie en kan dus aangepast worden door gebruiker

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            return base.BeginExecuteCore(callback, state); // verder base afwerken
        }

        public ActionResult SetCulture(string culture, string returnaction) //om mogelijkheid te hebben taal aanpassen
        {
            HttpCookie cookie = Request.Cookies["culture"];
            if (cookie != null)
            {
                cookie.Value = culture;
            }
            else
            {
                cookie = new HttpCookie("culture"); // if cookie do not exist, make new
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1); // valid for 1 year
            }
            Response.Cookies.Add(cookie); // doorgestuurd naar browser

            return RedirectToAction(returnaction);
        }
    }
}
