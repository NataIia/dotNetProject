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
    public class UurRegistratieDetailsController : Controller
    {
        private UurRegistratieDetailsService uurRegistratieDetailsService;

        // GET: UurRegistratieDetails
        public ActionResult Index()
        {
            /// Use viewmodel to switch between all UurenRegistratie and newmade UurRegistratie in view and controller
            UurRegistratieDetailsViewModel uurRegistratieDetailsViewModel = new UurRegistratieDetailsViewModel();
            /// initialisatie van de viewmodel properties + doorgeven aan de overeenkomstige view
            /// Opgelet: het model van de view moet aangepast worden naar dit viewmodel!
            uurRegistratieDetailsViewModel.UurRegistratieDetails = uurRegistratieDetailsService.GetAllDetailsForUurRegistratie();
            uurRegistratieDetailsViewModel.UurRegistratieDetail = new UurRegistratieDetails();
            return View(uurRegistratieDetailsViewModel);
        }

        // GET: UurRegistratieDetails/Details/5
        public ActionResult Details(int id)
        {
            UurRegistratieDetailsViewModel uurRegistratieDetailsViewModel = new UurRegistratieDetailsViewModel();
            uurRegistratieDetailsViewModel.UurRegistratieDetails = uurRegistratieDetailsService.GetAllDetailsForUurRegistratie();
            uurRegistratieDetailsViewModel.UurRegistratieDetail = uurRegistratieDetailsService.GetUurRegistratieDetails(id);
            return View(uurRegistratieDetailsViewModel);
        }

        // GET: UurRegistratieDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UurRegistratieDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartTijd,StartDate,EindTijd,EindDate,TypeWerk,TeFactureren")] UurRegistratieDetails uurRegistratieDetails)
        {
            if (ModelState.IsValid)
            {
                uurRegistratieDetailsService.InsertOrUpdateDetails(uurRegistratieDetails);
                uurRegistratieDetailsService.SaveChanges();
                return RedirectToAction("Index");
            }
            //something is wrong
            return View();
        }

        // GET: UurRegistratieDetails/Edit/5
        public ActionResult Edit(int id)
        {
            UurRegistratieDetailsViewModel uurRegistratieDetailsViewModel = new UurRegistratieDetailsViewModel();
            uurRegistratieDetailsViewModel.UurRegistratieDetail = uurRegistratieDetailsService.GetUurRegistratieDetails(id);
            return View(uurRegistratieDetailsViewModel);
        }

        // POST: UurRegistratieDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartTijd,EindTijd,StartDate,EindDate,TypeWerk,TeFactureren")] UurRegistratieDetails uurRegistratieDetails)
        {
            if (ModelState.IsValid)
            {
                uurRegistratieDetailsService.InsertOrUpdateDetails(uurRegistratieDetails);
                uurRegistratieDetailsService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uurRegistratieDetails);
        }

        // GET: UurRegistratieDetails/Delete/5
        public ActionResult Delete(int id)
        {

            return View(uurRegistratieDetailsService.GetUurRegistratieDetails(id));
        }

        // POST: UurRegistratieDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            uurRegistratieDetailsService.DeleteUurRegistratieDetails(id);
            uurRegistratieDetailsService.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((IDisposable)uurRegistratieDetailsService).Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
