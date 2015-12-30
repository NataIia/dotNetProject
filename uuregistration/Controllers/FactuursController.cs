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
    public class FactuursController : Controller
    {
        private IFacturenService factuurService;
        private IKlantenService klantenService;
        public FactuursController(IFacturenService factuurService, IKlantenService klantenService)
        {
            this.factuurService = factuurService;
            this.klantenService = klantenService;
        }

        // GET: Factuurs
        public ActionResult Index()
        {
            FacturenIndexViewModel factuurIndexViewModel = new FacturenIndexViewModel();
            factuurIndexViewModel.Facturen = factuurService.GetAllFacturen();
            factuurIndexViewModel.Factuur = new Factuur();
            factuurIndexViewModel.Klanten = klantenService.GetAllKlanten();
            return View(factuurIndexViewModel);
        }

        // GET: Factuurs/Details/5
        public ActionResult Details(int id)
        {
            FacturenIndexViewModel factuurIndexViewModel = new FacturenIndexViewModel();
            factuurIndexViewModel.Facturen = factuurService.GetAllFacturen();
            factuurIndexViewModel.Factuur = new Factuur();
            factuurIndexViewModel.Details = factuurService.GetDetailsForFactuur(id);
            factuurIndexViewModel.Detail = factuurService.GetFactuurDetails(id);
            return View(factuurIndexViewModel);
        }

        // GET: Factuurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Factuurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FactuurJaar,FactuurNummer,FactuurDatum,Totaal")] Factuur factuur)
        {
            if (ModelState.IsValid)
            {
                factuurService.InsertOrUpdate(factuur);
                factuurService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(factuur);
        }

        // GET: Factuurs/Edit/5
        public ActionResult Edit(int id)
        {
            FacturenIndexViewModel factuurIndexViewModel = new FacturenIndexViewModel();
            factuurIndexViewModel.Facturen = factuurService.GetAllFacturen();
            factuurIndexViewModel.Factuur = new Factuur();
            factuurIndexViewModel.Details = factuurService.GetDetailsForFactuur(id);
            factuurIndexViewModel.Detail = factuurService.GetFactuurDetails(id);
            return View(factuurIndexViewModel);
        }

        // POST: Factuurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FactuurJaar,FactuurNummer,FactuurDatum,Totaal")] Factuur factuur)
        {
            if (ModelState.IsValid)
            {
                factuurService.InsertOrUpdate(factuur);
                factuurService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(factuur);
        }

        // GET: Factuurs/Delete/5
        public ActionResult Delete(int id)
        {
            return View(factuurService.GetFactuur(id));
        }

        // POST: Factuurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            factuurService.DeleteFactuur(id);
            factuurService.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((IDisposable)factuurService).Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// De Create_New functie wordt opgeroepen via AJAX en zal een PartialViewResult teruggeven
        /// </summary>
        /// <param name="viewmodel">De AJAX call zal het model van de view (GebruikersIndexViewModel) meegeven als parameter.
        /// Hieruit wordt dan de nieuwe persoon gehaald via zijn property en aan de facturenService gegeven om op te slaan in de 
        /// databank (via de Add functie)</param>
        /// <returns>De lijst van alle personen (PartialView) opgevraagd via de facturenService</returns>
        [HttpPost]
        public PartialViewResult Create_New(FacturenIndexViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(viewmodel.Factuur.Klant.Bedrijfsnaam))
                {
                    factuurService.InsertOrUpdate(viewmodel.Factuur);
                    factuurService.SaveChanges();
                }
                return PartialView("FacturenLijstControl", factuurService.GetAllFacturen());
            }
            return PartialView("FacturenLijstControl");
        }
    }
}
