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
    public class UurRegistratiesController : Controller
    {
        private IUurRegistratieService uurRegistratieService;
        public UurRegistratiesController(IUurRegistratieService uurRegistratieService)
        {
            this.uurRegistratieService = uurRegistratieService;
        }
        // GET: UurRegistraties
        public ActionResult Index()
        {
            /// Use viewmodel to switch between all UurenRegistratie and newmade UurRegistratie in view and controller
            UurRegistratieViewModel uurRegistratieViewModel = new UurRegistratieViewModel();
            /// initialisatie van de viewmodel properties + doorgeven aan de overeenkomstige view
            /// Opgelet: het model van de view moet aangepast worden naar dit viewmodel!
            uurRegistratieViewModel.UurRegistraties = uurRegistratieService.GetAllUurRegistraties();
            uurRegistratieViewModel.UurRegistratie = new UurRegistratie();
            return View(uurRegistratieViewModel);
        }

        // GET: UurRegistraties/Details/5
        public ActionResult Details(int id)
        {
            UurRegistratieViewModel uurRegistratieViewModel = new UurRegistratieViewModel();
            uurRegistratieViewModel.UurRegistraties = uurRegistratieService.GetAllUurRegistraties();
            uurRegistratieViewModel.UurRegistratie = uurRegistratieService.GetUurRegistratie(id);
            uurRegistratieViewModel.Details = uurRegistratieService.GetDetailsForUurRegistratie(id);
            uurRegistratieViewModel.Detail = uurRegistratieService.GetUurRegistratieDetails(id);

            return View(uurRegistratieViewModel);
        }

        // GET: UurRegistraties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UurRegistraties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titel,Omschrijving")] UurRegistratie uurRegistratie)
        {
            if (ModelState.IsValid)
            {
                uurRegistratieService.InsertOrUpdate(uurRegistratie);
                uurRegistratieService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: UurRegistraties/Edit/5
        public ActionResult Edit(int id)
        {
            UurRegistratieViewModel uurRegistratieViewModel = new UurRegistratieViewModel();
            uurRegistratieViewModel.UurRegistraties = uurRegistratieService.GetAllUurRegistraties();
            uurRegistratieViewModel.UurRegistratie = uurRegistratieService.GetUurRegistratie(id);
            uurRegistratieViewModel.Details = uurRegistratieService.GetDetailsForUurRegistratie(id);
            uurRegistratieViewModel.Detail = uurRegistratieService.GetUurRegistratieDetails(id);

            return View(uurRegistratieViewModel);
        }

        // POST: UurRegistraties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titel,Omschrijving")] UurRegistratie uurRegistratie)
        {
            if (ModelState.IsValid)
            {
                uurRegistratieService.InsertOrUpdate(uurRegistratie);
                uurRegistratieService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uurRegistratie);
        }

        // GET: UurRegistraties/Delete/5
        public ActionResult Delete(int id)
        {
            return View(uurRegistratieService.GetUurRegistratie(id));
        }

        // POST: UurRegistraties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            uurRegistratieService.DeleteUurRegistratie(id);
            uurRegistratieService.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((IDisposable)uurRegistratieService).Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// De Index_Create functie wordt opgeroepen via AJAX en zal een PartialViewResult teruggeven
        /// </summary>
        /// <param name="viewmodel">De AJAX call zal het model van de view (UurRegistratieViewModel) meegeven als parameter.
        /// Hieruit wordt dan de nieuwe persoon gehaald via zijn property en aan de peopleService gegeven om op te slaan in de 
        /// databank (via de Add functie)</param>
        /// <returns>De lijst van alle uren (PartialView) opgevraagd via de uurRegistratieService</returns>
        [HttpPost]
        public PartialViewResult Index_Create(UurRegistratieViewModel viewmodel, string param1)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            int id = Int32.Parse(param1);
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(viewmodel.Detail.StartTijd.ToString()))
                {
                    viewmodel.Detail.UurRegistratie = uurRegistratieService.GetUurRegistratie(id);
                    uurRegistratieService.InsertOrUpdateDetails(viewmodel.Detail);
                    uurRegistratieService.SaveChanges();
                }
                return PartialView("../UurRegistratieDetails/UurRegistratieDetailsLijstControl", uurRegistratieService.GetUurRegistratieDetails(id));
            }
            return PartialView("../UurRegistratieDetails/UurRegistratieDetailsLijstControl");

        }
    }
}
