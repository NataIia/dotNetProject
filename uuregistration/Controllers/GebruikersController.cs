using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using uuregistration.DataAccessLayer;
using uuregistration.Models;
using uuregistration.Services;
using uuregistration.ViewModels;

namespace uuregistration.Controllers
{
    public class GebruikersController : Controller
    {

        /// <summary>
        /// de koppeling tussen de GebruikerService implementatie en de Controllers wordt gemaakt 
        /// via de interface = loose coupling!
        /// </summary>
        private IGebruikersService gebruikersService;

        /// <summary>
        /// De constructor van deze controller wordt opgeroepen via het unity framework die 
        /// een GebruikersService object zal aanmaken en meegeven als parameter 
        /// (= injection van de service / Dependency Injection)
        /// </summary>
        /// <param name="gebruikersService"></param>
        public GebruikersController(IGebruikersService gebruikersService)
        {
            /// toewijzen van de globale peopleservice
            this.gebruikersService = gebruikersService;
        }

        // GET: Gebruikers
        public ActionResult Index()
        {
            /// Use viewmodel to switch between all Gebruikers and newmade Gebruiker in view and controller
            GebruikersIndexViewModel gebruikersIndexViewModel = new GebruikersIndexViewModel();
            /// initialisatie van de viewmodel properties + doorgeven aan de overeenkomstige view
            /// Opgelet: het model van de view moet aangepast worden naar dit viewmodel!
            gebruikersIndexViewModel.Gebruikers = gebruikersService.GetAllGebruikers();
            gebruikersIndexViewModel.Gebruiker = new Gebruiker();
            return View(gebruikersIndexViewModel);
        }

        // GET: Gebruikers/Details/5
        public ActionResult Details(int id)
        {
            return View(gebruikersService.GetGebruiker(id));
        }

        // GET: Gebruikers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gebruikers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,Voornaam,Achternaam,Email")] Gebruiker gebruiker)
        {
            if (ModelState.IsValid)
            {
                gebruikersService.InsertOrUpdate(gebruiker);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Gebruikers/Edit/5
        public ActionResult Edit(int id)
        {
            return View(gebruikersService.GetGebruiker(id));
        }

        // POST: Gebruikers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Voornaam,Achternaam,Email")] Gebruiker gebruiker)
        {
            if (ModelState.IsValid)
            {
                gebruikersService.InsertOrUpdate(gebruiker);
                gebruikersService.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(gebruiker);
            }
        }

        // GET: Gebruikers/Delete/5
        public ActionResult Delete(int id)
        {         
            return View(gebruikersService.GetGebruiker(id));
        }

        // POST: Gebruikers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gebruikersService.Delete(id);
            gebruikersService.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((IDisposable)gebruikersService).Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// De Index_Create functie wordt opgeroepen via AJAX en zal een PartialViewResult teruggeven
        /// </summary>
        /// <param name="viewmodel">De AJAX call zal het model van de view (GebruikersIndexViewModel) meegeven als parameter.
        /// Hieruit wordt dan de nieuwe persoon gehaald via zijn property en aan de peopleService gegeven om op te slaan in de 
        /// databank (via de Add functie)</param>
        /// <returns>De lijst van alle personen (PartialView) opgevraagd via de peopleService</returns>
        [HttpPost]
        public PartialViewResult Index_Create(GebruikersIndexViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(viewmodel.Gebruiker.Voornaam))
                {
                    gebruikersService.InsertOrUpdate(viewmodel.Gebruiker);
                    gebruikersService.SaveChanges();
                }
                return PartialView("GebruikersLijstControl", gebruikersService.GetAllGebruikers());
            }
            return PartialView("GebruikersLijstControl");
        }
    }
}
