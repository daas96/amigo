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
        Database1Entities db = new Database1Entities();

        // GET: /Search/Search
        public ActionResult Index(string dep, string arr, DateTime date)
        {

            return View(db.travel.Where(x=> x.departure.Equals(dep) && x.arrival.Equals(arr) && x.date.Equals(date)).ToList());
        }
    }
}