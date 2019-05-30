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
                using (Database1Entities2 db = new Database1Entities2())
                {
                    model.Id = 1;
                    db.travel.Add(model);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.message = "Your trip from " + model.departure + " has been successfully posted !";
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            return View ();
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