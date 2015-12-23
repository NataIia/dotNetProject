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
    public class UurRegistratiesController : Controller
    {
        private UuregistratieContext db = new UuregistratieContext();

        // GET: UurRegistraties
        public ActionResult Index()
        {
            return View(db.UurenRegistratie.ToList());
        }

        // GET: UurRegistraties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UurRegistratie uurRegistratie = db.UurenRegistratie.Find(id);
            if (uurRegistratie == null)
            {
                return HttpNotFound();
            }
            return View(uurRegistratie);
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
                db.UurenRegistratie.Add(uurRegistratie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uurRegistratie);
        }

        // GET: UurRegistraties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UurRegistratie uurRegistratie = db.UurenRegistratie.Find(id);
            if (uurRegistratie == null)
            {
                return HttpNotFound();
            }
            return View(uurRegistratie);
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
                db.Entry(uurRegistratie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uurRegistratie);
        }

        // GET: UurRegistraties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UurRegistratie uurRegistratie = db.UurenRegistratie.Find(id);
            if (uurRegistratie == null)
            {
                return HttpNotFound();
            }
            return View(uurRegistratie);
        }

        // POST: UurRegistraties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UurRegistratie uurRegistratie = db.UurenRegistratie.Find(id);
            db.UurenRegistratie.Remove(uurRegistratie);
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
