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
    public class Station_DetailsController : Controller
    {
        private RailwayBookingEntities db = new RailwayBookingEntities();

        // GET: Station_Details
        public ActionResult Index()
        {
            var station_Details = db.Station_Details.Include(s => s.Station).Include(s => s.Train);
            return View(station_Details.ToList());
        }

        // GET: Station_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station_Details station_Details = db.Station_Details.Find(id);
            if (station_Details == null)
            {
                return HttpNotFound();
            }
            return View(station_Details);
        }

        // GET: Station_Details/Create
        public ActionResult Create()
        {
            ViewBag.Station_ID = new SelectList(db.Stations, "Station_ID", "Station_Name");
            ViewBag.Train_ID = new SelectList(db.Trains, "Train_ID", "TrainName");
            return View();
        }

        // POST: Station_Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Train_ID,Station_ID,Sequence_No,Station_Arrival_Time,Station_Departure_Time")] Station_Details station_Details)
        {
            if (ModelState.IsValid)
            {
                db.Station_Details.Add(station_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Station_ID = new SelectList(db.Stations, "Station_ID", "Station_Name", station_Details.Station_ID);
            ViewBag.Train_ID = new SelectList(db.Trains, "Train_ID", "TrainName", station_Details.Train_ID);
            return View(station_Details);
        }

        // GET: Station_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station_Details station_Details = db.Station_Details.Find(id);
            if (station_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Station_ID = new SelectList(db.Stations, "Station_ID", "Station_Name", station_Details.Station_ID);
            ViewBag.Train_ID = new SelectList(db.Trains, "Train_ID", "TrainName", station_Details.Train_ID);
            return View(station_Details);
        }

        // POST: Station_Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Train_ID,Station_ID,Sequence_No,Station_Arrival_Time,Station_Departure_Time")] Station_Details station_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(station_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Station_ID = new SelectList(db.Stations, "Station_ID", "Station_Name", station_Details.Station_ID);
            ViewBag.Train_ID = new SelectList(db.Trains, "Train_ID", "TrainName", station_Details.Train_ID);
            return View(station_Details);
        }

        // GET: Station_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station_Details station_Details = db.Station_Details.Find(id);
            if (station_Details == null)
            {
                return HttpNotFound();
            }
            return View(station_Details);
        }

        // POST: Station_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Station_Details station_Details = db.Station_Details.Find(id);
            db.Station_Details.Remove(station_Details);
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
