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
    public class Trip_PriceController : Controller
    {
        private RailwayBookingEntities db = new RailwayBookingEntities();

        // GET: Trip_Price
        public ActionResult Index()
        {
            var trip_Price = db.Trip_Price.Include(t => t.Coach_Type).Include(t => t.Seat_Type).Include(t => t.Train);
            return View(trip_Price.ToList());
        }

        // GET: Trip_Price/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip_Price trip_Price = db.Trip_Price.Find(id);
            if (trip_Price == null)
            {
                return HttpNotFound();
            }
            return View(trip_Price);
        }

        // GET: Trip_Price/Create
        public ActionResult Create()
        {
            ViewBag.Coach_ID = new SelectList(db.Coach_Type, "Coach_ID", "Coach_Type1");
            ViewBag.Seat_Type_ID = new SelectList(db.Seat_Type, "Seat_Type_ID", "Seat_Type_Name");
            ViewBag.Train_ID = new SelectList(db.Trains, "Train_ID", "TrainName");
            return View();
        }

        // POST: Trip_Price/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Trip_ID,Train_ID,Seat_Type_ID,Coach_ID,Rate_Current")] Trip_Price trip_Price)
        {
            if (ModelState.IsValid)
            {
                db.Trip_Price.Add(trip_Price);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Coach_ID = new SelectList(db.Coach_Type, "Coach_ID", "Coach_Type1", trip_Price.Coach_ID);
            ViewBag.Seat_Type_ID = new SelectList(db.Seat_Type, "Seat_Type_ID", "Seat_Type_Name", trip_Price.Seat_Type_ID);
            ViewBag.Train_ID = new SelectList(db.Trains, "Train_ID", "TrainName", trip_Price.Train_ID);
            return View(trip_Price);
        }

        // GET: Trip_Price/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip_Price trip_Price = db.Trip_Price.Find(id);
            if (trip_Price == null)
            {
                return HttpNotFound();
            }
            ViewBag.Coach_ID = new SelectList(db.Coach_Type, "Coach_ID", "Coach_Type1", trip_Price.Coach_ID);
            ViewBag.Seat_Type_ID = new SelectList(db.Seat_Type, "Seat_Type_ID", "Seat_Type_Name", trip_Price.Seat_Type_ID);
            ViewBag.Train_ID = new SelectList(db.Trains, "Train_ID", "TrainName", trip_Price.Train_ID);
            return View(trip_Price);
        }

        // POST: Trip_Price/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Trip_ID,Train_ID,Seat_Type_ID,Coach_ID,Rate_Current")] Trip_Price trip_Price)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trip_Price).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Coach_ID = new SelectList(db.Coach_Type, "Coach_ID", "Coach_Type1", trip_Price.Coach_ID);
            ViewBag.Seat_Type_ID = new SelectList(db.Seat_Type, "Seat_Type_ID", "Seat_Type_Name", trip_Price.Seat_Type_ID);
            ViewBag.Train_ID = new SelectList(db.Trains, "Train_ID", "TrainName", trip_Price.Train_ID);
            return View(trip_Price);
        }

        // GET: Trip_Price/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip_Price trip_Price = db.Trip_Price.Find(id);
            if (trip_Price == null)
            {
                return HttpNotFound();
            }
            return View(trip_Price);
        }

        // POST: Trip_Price/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trip_Price trip_Price = db.Trip_Price.Find(id);
            db.Trip_Price.Remove(trip_Price);
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
