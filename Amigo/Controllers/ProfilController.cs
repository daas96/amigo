using Amigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amigo.Controllers
{
    public class ProfilController : Controller
    {
        private Database1Entities2 db = new Database1Entities2();
        // GET: Profil
        public ActionResult Index()
        {
            return RedirectToAction("Details", new { fn = User.Identity.Name });
        }

        public ActionResult Details(string fn)
        {
            users us = db.users.Where(p => p.firstname == fn).FirstOrDefault();
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(us);
        }
    }
}