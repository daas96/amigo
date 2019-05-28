using Amigo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Amigo.Controllers
{
    public class InscriptionController : Controller
    {
        Database1Entities db = new Database1Entities();

        // GET: Inscription

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

      
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(user us)
        {
            if (ModelState.IsValid)
            {
                using(Database1Entities db= new Database1Entities())
                {
                    db.user.Add(us);
                    db.SaveChanges();
                }

                ModelState.Clear();
                ViewBag.Message = us.firstname + " " + us.lastname + " " + "has successfully registered";
            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(user us)
        {
            using (Database1Entities db = new Database1Entities())
            {
                var usr = db.user.Single(u => u.email.Equals(us.email) && u.password.Equals(us.password));
                if(usr != null) {
                    Session["SessionID"] = usr.Id.ToString();
                    Session["FirstName"] = usr.firstname.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is wrong");
                }
                return View();
            }
        }
        public ActionResult LoggedIn()
        {
            if(Session["SessionID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["SessionID"] = null;
            return Redirect("/");
        }
    }
}