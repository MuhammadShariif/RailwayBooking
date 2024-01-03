using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RailwayBooking;

namespace RailwayBooking.Controllers
{
    public class Coach_TypeController : Controller
    {
        private RailwayBookingEntities db = new RailwayBookingEntities();

        // GET: Coach_Type
        public ActionResult Index()
        {
            return View(db.Coach_Type.ToList());
        }

        // GET: Coach_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coach_Type coach_Type = db.Coach_Type.Find(id);
            if (coach_Type == null)
            {
                return HttpNotFound();
            }
            return View(coach_Type);
        }

        // GET: Coach_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coach_Type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Coach_ID,Coach_Type1,Capacity")] Coach_Type coach_Type)
        {
            if (ModelState.IsValid)
            {
                db.Coach_Type.Add(coach_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coach_Type);
        }

        // GET: Coach_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coach_Type coach_Type = db.Coach_Type.Find(id);
            if (coach_Type == null)
            {
                return HttpNotFound();
            }
            return View(coach_Type);
        }

        // POST: Coach_Type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Coach_ID,Coach_Type1,Capacity")] Coach_Type coach_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coach_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coach_Type);
        }

        // GET: Coach_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coach_Type coach_Type = db.Coach_Type.Find(id);
            if (coach_Type == null)
            {
                return HttpNotFound();
            }
            return View(coach_Type);
        }

        // POST: Coach_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coach_Type coach_Type = db.Coach_Type.Find(id);
            db.Coach_Type.Remove(coach_Type);
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
