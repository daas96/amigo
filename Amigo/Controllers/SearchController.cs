using Amigo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amigo.Controllers
{
    public class SearchController : Controller
    {
        Database1Entities2 db = new Database1Entities2();
        // GET: /Search/Search
        [HttpGet]
        public ActionResult Index(string dep, string arr)
        {

            return View(db.travel.Where(x => x.departure.Equals(dep) && x.arrival.Equals(arr)).ToList());
        }

        [HttpPost]
        public ActionResult ShowTrip(int tripId)
        {
            return RedirectToAction("Index", "DisplayTrip", new { id = tripId });
        }
    }
}