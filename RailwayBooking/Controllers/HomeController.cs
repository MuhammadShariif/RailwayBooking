using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using RailwayBooking.Models;
using System.Web.Security;

namespace RailwayBooking.Controllers
{
    public class HomeController : Controller
    {
        private RailwayBookingEntities db = new RailwayBookingEntities();
        // GET: Home

        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Log_in login)
        {
            bool userExist = db.Customers.Any(x => x.CustomerPhone == login.Customer_Phone && x.Password == login.Password);
            Customer customer = db.Customers.FirstOrDefault(x => x.CustomerPhone == login.Customer_Phone && x.Password == login.Password);
            if (userExist)
            {
                if (customer.CustomerPhone == 03494115088 && customer.Password == "12")
                {
                    FormsAuthentication.SetAuthCookie(customer.CustomerName, false);
                    return RedirectToAction("Dashboard", "Home");
                }
                FormsAuthentication.SetAuthCookie(customer.CustomerName, false);
                return RedirectToAction("Index", "UserBooking");
            }
            ModelState.AddModelError("", "Invalid Phone Number or Password");
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Customer customer)
        {

            return RedirectToAction("Create", "Customers");
        }
    }
}