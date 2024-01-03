using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayBooking.Controllers
{
    public class UserBookingController : Controller
    {
        private RailwayBookingEntities db = new RailwayBookingEntities();
        // GET: UserBooking
        public ActionResult Index()
        {
            return RedirectToAction("SelectTrain");
        }

        public ActionResult SelectTrain()
        {
            TempData["Train_Name"] = db.Trains.Select(l => l.TrainName).ToList();
            string trainname = TempData["Train_Name"].ToString();
            Session["Train_ID"] = db.Trains.Where(t => t.TrainName == trainname).Select(l => l.Train_ID).FirstOrDefault();
            return View(); 
        }

        [HttpPost]
        public ActionResult SelectTrain(string selected_train)
        {
            TempData["SelectedTrain"] = selected_train;
            Session["SelectedTrain"] = selected_train;
            return RedirectToAction("SelectTrip");
        }


        public ActionResult SelectTrip() 
        {
            string selectedTrain = Session["SelectedTrain"] as string;
            if (selectedTrain != null)
            {
                TempData["Trip_ID"] = db.Trips.Where(t => t.Train.TrainName == selectedTrain).Select(l => l.Trip_ID).ToList();
            }
            else
            {
                TempData["Trip_ID"] = null;
            }
            return View();

        }

        [HttpPost]
        public ActionResult SelectTrip(int selected_trip)
        {
            TempData["SelectedTrip"] = selected_trip;
            Session["SelectedTrip"] = selected_trip;
            return RedirectToAction("SelectCoach_No");
        }

        public ActionResult SelectCoach_No() 
        {
            string selectedTrain = Session["SelectedTrain"] as string;
            if (TempData["SelectedTrain"] != null)
            {
                TempData["Coach_No"] = db.Coaches.Where(t => t.Train.TrainName == selectedTrain).Select(l => l.Coach_No).ToList();
            }
            else
            {
                TempData["Coach_No"] = Session["SelectedTrain"];
            }
            return View();
        }

        [HttpPost]
        public ActionResult SelectCoach_No(int selected_coach_no)
        {
            Session["SelectedCoachNo"] = selected_coach_no;
            TempData["SelectedCoachNo"] = selected_coach_no;
            return RedirectToAction("SelectSeat_No");
        }


        public ActionResult SelectSeat_No() 
        {
            string selectedTrain = Session["SelectedTrain"] as string;
            string selectedCoachNo = Session["SelectedCoachNo"] as string;
            if (selectedTrain != null && selectedCoachNo != null)
            {
                int coachid = db.Coaches.Where(t => t.Train.TrainName == selectedTrain && t.Coach_No == Convert.ToInt32(selectedCoachNo)).Select(l => l.Coach_ID).FirstOrDefault();
                Session["Coach_ID"] = coachid;
                if (coachid != 0)
                {
                    Session["Seat_No"] = db.Seats.Where(t => t.Train.TrainName == selectedTrain && t.Coach_ID == coachid).Select(l => l.Seat_No).ToList();
                }
            }
            else 
            {
                TempData["Seat_No"] = null;
            }
            return View();
        }

        [HttpPost]
        public ActionResult SelectSeat_No(int selected_seat_no)
        {
            Session["SelectedSeatNo"] = selected_seat_no;
            TempData["SelectedSeatNo"] = selected_seat_no;
            return RedirectToAction("SelectSeat_Type");
        }

        public ActionResult SelectSeat_Type() 
        {
            string selectedTrain = Session["SelectedTrain"] as string;
            string selectedCoachNo = Session["SelectedCoachNo"] as string;
            if (selectedTrain != null && selectedCoachNo != null)
            {
                int coachid = db.Coaches.Where(t => t.Train.TrainName == selectedTrain && t.Coach_No == Convert.ToInt32(selectedCoachNo)).Select(l => l.Coach_ID).FirstOrDefault();
                int seattypeid = db.Seats.Where(t => t.Train.TrainName == selectedTrain && t.Coach_ID == coachid).Select(l => l.Seat_Type_ID).FirstOrDefault();
                TempData["Seat_Type_Name"] = db.Seat_Type.Where(t => t.Seat_Type_ID == seattypeid).Select(l => l.Seat_Type_Name).ToList();
            }
            else
            {
                TempData["Seat_Type_Name"] = null;
            }
            return View(); 
        }

        [HttpPost]
        public ActionResult SelectSeat_Type(string selected_seat_type_name)
        {
            Session["SelectedSeatTypeName"] = selected_seat_type_name;
            TempData["SelectedSeatTypeName"] = selected_seat_type_name;
            return View("other_Values");
        }

        public ActionResult Other_Values()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Other_Values(string selected_trip_start_location, string selected_trip_end_location)
        {
            Session["SelectedTripStartLocation"] = selected_trip_start_location;
            Session["SelectedTripEndLocation"] = selected_trip_end_location;
            Booking booking = new Booking();
            booking.Train_ID = (int)Session["Train_ID"];
            booking.Trip_ID = (int)Session["SelectedTrip"];

            Booking_Detail booking_Detail = new Booking_Detail();
            booking_Detail.Coach_ID = (int)Session["Coach_ID"];
            booking_Detail.Seat_No = (int)Session["SelectedSeatNo"];

            Trip_Price trip_Price = new Trip_Price();
            booking_Detail.Booking_Price = trip_Price.Rate_Current;
            db.Bookings.Add(booking);
            db.SaveChanges();
            db.Booking_Detail.Add(booking_Detail);
            db.SaveChanges();
            return RedirectToAction("Congratulation");

        }

        public ActionResult Congratulation()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Congratulation(int i)
        {

            return RedirectToAction("Index");
        }
    }
}