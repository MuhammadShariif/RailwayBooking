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
    public class Booking_DetailController : Controller
    {
        private RailwayBookingEntities db = new RailwayBookingEntities();

        // GET: Booking_Detail
        public ActionResult Index()
        {
            var booking_Detail = db.Booking_Detail.Include(b => b.Booking);
            return View(booking_Detail.ToList());
        }

        // GET: Booking_Detail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking_Detail booking_Detail = db.Booking_Detail.Find(id);
            if (booking_Detail == null)
            {
                return HttpNotFound();
            }
            return View(booking_Detail);
        }

        // GET: Booking_Detail/Create
        public ActionResult Create()
        {
            ViewBag.Booking_ID = new SelectList(db.Bookings, "Booking_ID", "Booking_ID");
            return View();
        }

        // POST: Booking_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Booking_ID,Seat_No,Coach_ID,Booking_Price")] Booking_Detail booking_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Booking_Detail.Add(booking_Detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Booking_ID = new SelectList(db.Bookings, "Booking_ID", "Booking_ID", booking_Detail.Booking_ID);
            return View(booking_Detail);
        }

        // GET: Booking_Detail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking_Detail booking_Detail = db.Booking_Detail.Find(id);
            if (booking_Detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.Booking_ID = new SelectList(db.Bookings, "Booking_ID", "Booking_ID", booking_Detail.Booking_ID);
            return View(booking_Detail);
        }

        // POST: Booking_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Booking_ID,Seat_No,Coach_ID,Booking_Price")] Booking_Detail booking_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking_Detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Booking_ID = new SelectList(db.Bookings, "Booking_ID", "Booking_ID", booking_Detail.Booking_ID);
            return View(booking_Detail);
        }

        // GET: Booking_Detail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking_Detail booking_Detail = db.Booking_Detail.Find(id);
            if (booking_Detail == null)
            {
                return HttpNotFound();
            }
            return View(booking_Detail);
        }

        // POST: Booking_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking_Detail booking_Detail = db.Booking_Detail.Find(id);
            db.Booking_Detail.Remove(booking_Detail);
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
