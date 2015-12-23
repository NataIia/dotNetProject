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
    public class KlantsController : Controller
    {
        /// <summary>
        /// de koppeling tussen de KlantenService implementatie en de Controllers wordt gemaakt 
        /// via de interface = loose coupling!
        /// </summary>
        private IKlantenService klantenService;

        /// <summary>
        /// De constructor van deze controller wordt opgeroepen via het unity framework die 
        /// een KlantenService object zal aanmaken en meegeven als parameter 
        /// (= injection van de service / Dependency Injection)
        /// </summary>
        /// <param name="klantenService"></param>
        public KlantsController(IKlantenService klantenService)
        {
            this.klantenService = klantenService;
        }

        // GET: Klants
        public ActionResult Index()
        {
            KlantenIndexViewModel klantenIndexViewModel = new KlantenIndexViewModel();
            /// initialisatie van de viewmodel properties + doorgeven aan de overeenkomstige view
            /// Opgelet: het model van de view moet aangepast worden naar dit viewmodel!
            klantenIndexViewModel.Klanten = klantenService.GetAllKlanten();
            klantenIndexViewModel.Klant = new Klant();
            return View(klantenIndexViewModel);
        }

        // GET: Klants/Details/5
        public ActionResult Details(int id)
        {
             return View(klantenService.GetKlant(id));
        }

        // GET: Klants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Klants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ondernemingsnummer,Bedrijfsnaam,Adres,Postcode,Plaats")] Klant klant)
        {
            if (ModelState.IsValid)
            {
                klantenService.InsertOrUpdate(klant);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Klants/Edit/5
        public ActionResult Edit(int id)
        {
            return View(klantenService.GetKlant(id));
        }

        // POST: Klants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ondernemingsnummer,Bedrijfsnaam,Adres,Postcode,Plaats")] Klant klant)
        {
            if (ModelState.IsValid)
            {
                klantenService.InsertOrUpdate(klant);
                klantenService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(klant);
        }

        // GET: Klants/Delete/5
        public ActionResult Delete(int id)
        {
            return View(klantenService.GetKlant(id));
        }

        // POST: Klants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            klantenService.GetKlant(id);
            klantenService.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((IDisposable)klantenService).Dispose();
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// De Index_Create functie wordt opgeroepen via AJAX en zal een PartialViewResult teruggeven
        /// </summary>
        /// <param name="viewmodel">De AJAX call zal het model van de view (KlantenIndexViewModel) meegeven als parameter.
        /// Hieruit wordt dan de nieuwe persoon gehaald via zijn property en aan de peopleService gegeven om op te slaan in de 
        /// databank (via de Add functie)</param>
        /// <returns>De lijst van alle personen (PartialView) opgevraagd via de peopleService</returns>
        [HttpPost]
        public PartialViewResult Index_Create(KlantenIndexViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(viewmodel.Klant.Bedrijfsnaam))
                {
                    klantenService.InsertOrUpdate(viewmodel.Klant);
                    klantenService.SaveChanges();
                }
                return PartialView("KlantenLijstControl", klantenService.GetAllKlanten());
            }
            return PartialView("KlantenLijstControl");
        }
    }
}
