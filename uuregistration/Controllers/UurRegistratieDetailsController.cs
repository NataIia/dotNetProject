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

namespace uuregistration.Controllers
{
    public class UurRegistratieDetailsController : Controller
    {
        private UuregistratieContext db = new UuregistratieContext();

        // GET: UurRegistratieDetails
        public ActionResult Index()
        {
            return View(db.UurRegistratieDetails.ToList());
        }

        // GET: UurRegistratieDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UurRegistratieDetails uurRegistratieDetails = db.UurRegistratieDetails.Find(id);
            if (uurRegistratieDetails == null)
            {
                return HttpNotFound();
            }
            return View(uurRegistratieDetails);
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
        public ActionResult Create([Bind(Include = "Id,StartTijd,EindTijd,TypeWerk,TeFactureren")] UurRegistratieDetails uurRegistratieDetails)
        {
            if (ModelState.IsValid)
            {
                db.UurRegistratieDetails.Add(uurRegistratieDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uurRegistratieDetails);
        }

        // GET: UurRegistratieDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UurRegistratieDetails uurRegistratieDetails = db.UurRegistratieDetails.Find(id);
            if (uurRegistratieDetails == null)
            {
                return HttpNotFound();
            }
            return View(uurRegistratieDetails);
        }

        // POST: UurRegistratieDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartTijd,EindTijd,TypeWerk,TeFactureren")] UurRegistratieDetails uurRegistratieDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uurRegistratieDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uurRegistratieDetails);
        }

        // GET: UurRegistratieDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UurRegistratieDetails uurRegistratieDetails = db.UurRegistratieDetails.Find(id);
            if (uurRegistratieDetails == null)
            {
                return HttpNotFound();
            }
            return View(uurRegistratieDetails);
        }

        // POST: UurRegistratieDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UurRegistratieDetails uurRegistratieDetails = db.UurRegistratieDetails.Find(id);
            db.UurRegistratieDetails.Remove(uurRegistratieDetails);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
