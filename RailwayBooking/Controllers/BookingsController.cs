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
    [Authorize]
    public class BookingsController : Controller
    {
        private RailwayBookingEntities db = new RailwayBookingEntities();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Customer).Include(b => b.Train);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.Customer_Phone = new SelectList(db.Customers, "CustomerPhone", "CustomerPhone");
            ViewBag.Train_ID = new SelectList(db.Trains, "Train_ID", "TrainName");
            ViewBag.Trip_ID = new SelectList(db.Trips, "Trip_ID", "Trip_ID");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Booking_ID,Booking_Date,Booking_Time,Customer_Phone,Trip_ID,Train_ID")] Booking booking)
        {
            if (booking.Booking_Date != default(DateTime))
            {
                booking.Booking_Date = DateTime.Now.Date; // Replace with your logic
            }

            if (booking.Booking_Time != default(TimeSpan))
            {
                booking.Booking_Time = DateTime.Now.TimeOfDay; // Replace with your logic
            }

            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_Phone = new SelectList(db.Customers, "CustomerPhone", "CustomerName", booking.Customer_Phone);
            ViewBag.Train_ID = new SelectList(db.Trains, "Train_ID", "TrainName", booking.Train_ID);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_Phone = new SelectList(db.Customers, "CustomerPhone", "CustomerName", booking.Customer_Phone);
            ViewBag.Train_ID = new SelectList(db.Trains, "Train_ID", "TrainName", booking.Train_ID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Booking_ID,Booking_Date,Booking_Time,Customer_Phone,Trip_ID,Train_ID")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_Phone = new SelectList(db.Customers, "CustomerPhone", "CustomerName", booking.Customer_Phone);
            ViewBag.Train_ID = new SelectList(db.Trains, "Train_ID", "TrainName", booking.Train_ID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
