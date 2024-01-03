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
    public class Seat_TypeController : Controller
    {
        private RailwayBookingEntities db = new RailwayBookingEntities();

        // GET: Seat_Type
        public ActionResult Index()
        {
            return View(db.Seat_Type.ToList());
        }

        // GET: Seat_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seat_Type seat_Type = db.Seat_Type.Find(id);
            if (seat_Type == null)
            {
                return HttpNotFound();
            }
            return View(seat_Type);
        }

        // GET: Seat_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seat_Type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Seat_Type_ID,Seat_Type_Name")] Seat_Type seat_Type)
        {
            if (ModelState.IsValid)
            {
                db.Seat_Type.Add(seat_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seat_Type);
        }

        // GET: Seat_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seat_Type seat_Type = db.Seat_Type.Find(id);
            if (seat_Type == null)
            {
                return HttpNotFound();
            }
            return View(seat_Type);
        }

        // POST: Seat_Type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Seat_Type_ID,Seat_Type_Name")] Seat_Type seat_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seat_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seat_Type);
        }

        // GET: Seat_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seat_Type seat_Type = db.Seat_Type.Find(id);
            if (seat_Type == null)
            {
                return HttpNotFound();
            }
            return View(seat_Type);
        }

        // POST: Seat_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seat_Type seat_Type = db.Seat_Type.Find(id);
            db.Seat_Type.Remove(seat_Type);
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
