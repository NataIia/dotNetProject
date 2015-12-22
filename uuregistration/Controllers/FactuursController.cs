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
    public class FactuursController : BaseController
    {
        private UuregistratieContext db = new UuregistratieContext();

        // GET: Factuurs
        public ActionResult Index()
        {
            return View(db.Facturen.ToList());
        }

        // GET: Factuurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factuur factuur = db.Facturen.Find(id);
            if (factuur == null)
            {
                return HttpNotFound();
            }
            return View(factuur);
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
                db.Facturen.Add(factuur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(factuur);
        }

        // GET: Factuurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factuur factuur = db.Facturen.Find(id);
            if (factuur == null)
            {
                return HttpNotFound();
            }
            return View(factuur);
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
                db.Entry(factuur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(factuur);
        }

        // GET: Factuurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factuur factuur = db.Facturen.Find(id);
            if (factuur == null)
            {
                return HttpNotFound();
            }
            return View(factuur);
        }

        // POST: Factuurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factuur factuur = db.Facturen.Find(id);
            db.Facturen.Remove(factuur);
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
