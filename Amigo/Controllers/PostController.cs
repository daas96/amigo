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
        travel trip = new travel();

        [HttpGet]
        public ActionResult Index()
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Index(travel model)
        {
            if (ModelState.IsValid)
            {
                int driverId = -1;
                trip = model;
                if (Session["SessionID"] != null && Int32.TryParse(Session["SessionID"].ToString(), out driverId))
                {
                    model.driver = driverId;
                    using (Database1Entities2 db = new Database1Entities2())
                    {
                        db.travel.Add(model);
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                    ViewBag.message = "Your trip from " + model.departure + " has been successfully posted !";
                }
                else
                {
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
        public ActionResult LoginOrSignUp(users user)
        {
            using (Database1Entities2 db = new Database1Entities2())
            {
                var usr = db.users.Single(u => u.email.Equals(user.email) && u.password.Equals(user.password));
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
                return View();
            }
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }


        [HttpGet]
        public ActionResult TripPosted()
        {
            ViewBag.Message = "Congratulations " + Session["FirstName"] + " for posting a trip from " + trip.departure + " to " + trip.arrival + "!";
            return View();
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


 
    }


}