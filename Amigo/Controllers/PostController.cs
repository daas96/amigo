using Amigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amigo.Controllers
{
    public class PostController : Controller
    {
        //Database1Entities db = new Database1Entities();
        private travel trip { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Index(travel model)
        {
            this.trip = new travel();
            if (ModelState.IsValid)
            {
                int driverId = -1;
                this.trip = model;
                this.trip.Id = 15;
                if (Session["SessionID"] != null && Int32.TryParse(Session["SessionID"].ToString(), out driverId))
                {
                    this.trip.driver = driverId;
                    SaveTripInSession();
                    using (Database1Entities2 db = new Database1Entities2())
                    {
                        db.travel.Add(this.trip);
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                    ViewBag.message = "Your trip from " + this.trip.departure + " has been successfully posted !";
                    return RedirectToAction("TripPosted");
                }
                else
                {
                    SaveTripInSession();
                    return RedirectToAction("LoginOrSignUp");
                }
            }
            return View();

        }

        public ActionResult Details(int id)
        {
            return View ();
        }

        [HttpGet]
        public ActionResult LoginOrSignUp()
        {
            return View();
        }

        //         [HttpPost]
        //         public ActionResult LoginOrSignUp(users model)
        //         {
        // 
        //             return View();
        //         }


        [HttpPost]
        public ActionResult LoginOrSignUp(users model)
        {
            using (Database1Entities2 db = new Database1Entities2())
            {
                var usr = db.users.Single(u => u.email.Equals(model.email) && u.password.Equals(model.password));
                if (usr != null)
                {
                    Session["SessionID"] = usr.Id.ToString();
                    Session["FirstName"] = usr.firstname.ToString();
                    return RedirectToAction("TripPosted");
                }
                else
                {
                    ViewBag.Message = "Username or password is wrong";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(users user)
        {
            if (ModelState.IsValid)
            {
                int driverId = -1;
                using (Database1Entities2 db = new Database1Entities2())
                    {
                        db.users.Add(user);
                        db.SaveChanges();

                        Session["SessionID"] = user.Id;
                        Session["FirstName"] = user.firstname;

                        GetTripFromSession();
                        if (Int32.TryParse(Session["SessionID"].ToString(), out driverId))
                        {
                            trip.driver = driverId;
                            SaveTripInSession();
                            return RedirectToAction("TripPosted");
                        }
                        ViewBag.Message = "Failed to Post your trip";
                        return View();
                    }     
            }
            return View();
        }


        [HttpGet]
        public ActionResult TripPosted()
        {
            GetTripFromSession();
            using (Database1Entities2 db = new Database1Entities2())
            {
                db.travel.Add(trip);
                db.SaveChanges();
                ViewBag.Message = "Congratulations " + Session["FirstName"] + " for posting a trip from " + trip.departure + " to " + trip.arrival + "!";
                DeleteTripInSession();
                return View();
            }
        }


        public ActionResult Create()
        {
            return View ();
        } 

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }
        
        public ActionResult Edit(int id)
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

        public ActionResult Delete(int id)
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

        public void SaveTripInSession()
        {
            if(this.trip != null)
            {
                Session["TripId"] = this.trip.Id;
                Session["TripDeparture"] = this.trip.departure;
                Session["TripArrival"] = this.trip.arrival;
                Session["TripDate"] = this.trip.date;
                
                Session["TripMaxPassengers"] = this.trip.nbpassengersmax;
                Session["TripDriver"] = this.trip.driver;
            }
        }

        public void GetTripFromSession()
        {
            this.trip = new travel();
            int tripId = -1;
            if (Int32.TryParse(Session["TripId"].ToString(), out tripId))
            {
                this.trip.Id = tripId;

                if (Session["TripDeparture"] != null && Session["TripArrival"] != null && Session["TripDate"] != null && Session["TripMaxPassengers"] != null && Session["TripDriver"] != null)
                {
                    int tripMaxPassengers = 0;
                    int tripDriverId = -1;
                    this.trip.departure = Session["TripDeparture"].ToString();
                    this.trip.arrival = Session["TripArrival"].ToString();
                    this.trip.departure = Session["TripDeparture"].ToString();
                    this.trip.nbpassengers = 0;
                    if (Int32.TryParse(Session["TripMaxPassengers"].ToString(), out tripMaxPassengers) && Int32.TryParse(Session["TripDriver"].ToString(), out tripDriverId))
                    {
                        this.trip.nbpassengersmax = tripMaxPassengers;
                        this.trip.driver = tripDriverId;
                        this.trip.driver = Int32.Parse(Session["SessionID"].ToString());
                    }
                    else
                    {
                        this.trip = null;
                    }
                }
                else
                {
                    this.trip = null;
                }
                
            }
        }

        public void DeleteTripInSession()
        {
            Session["TripId"] = null;
            Session["TripDeparture"] = null;
            Session["TripArrival"] = null;
            Session["TripDate"] = null;
            Session["TripHour"] = null;
            Session["TripMaxPassengers"] = null;
            Session["TripDriver"] = null;
        }


    }


}