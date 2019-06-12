using Amigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amigo.Controllers
{
    public class DisplayTripController : Controller
    {
        // GET: DisplayTrip

        [HttpGet]
        public ActionResult Index(int? tripId)
        {
            if (tripId.HasValue)
            {
                using (Database1Entities2 db = new Database1Entities2())
                {
                    travel trip = db.travel.Find(tripId);
                    if (trip == null)
                    {
                        return View("Error");
                    }
                    return View(trip);
                } 
            }
            return View("Error");
            
        }

        [HttpPost]
        public ActionResult Index(travel trip)
        {
            ViewBag.smoke = trip.smoke == true ? "Permitted" : "Not permitted";
            ViewBag.animal = trip.animal == true ? "Permitted" : "Not permitted";
            ViewBag.luggage = trip.luggage == true ? "Permitted" : "Not permitted";
            return View();
        }
    }
}