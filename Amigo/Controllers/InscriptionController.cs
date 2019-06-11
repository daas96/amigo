﻿using Amigo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Amigo.Controllers
{
    public class InscriptionController : Controller
    {

        private List<string> mailTable = new List<string>();
        // Database1Entities2 db = new Database1Entities2();

        // GET: Inscription
       
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(users us)
        {
            List<int> ranTable= new List<int>();
            Random r = new Random();
            bool exist = false;
            bool exist1=false;
            foreach (int i in ranTable)
            {
                if (!r.Next().Equals(i))
                {
                    exist = false;
                }
                else exist = true;
            }

            if(exist== false)
            {
                ranTable.Add(r.Next());
                us.Id = r.Next();
            }
            if (exist == true) {
                us.Id = r.Next()+1;
            }

          

            if (ModelState.IsValid)
            {
                using(Database1Entities2 db= new Database1Entities2())
                {
                    
                    foreach (string i in mailTable)
                    {
                        if (!us.email.Equals(i))
                        {
                            exist1 = false;

                        }
                        else { exist1 = true;
                            break;
                        }
                    }

                    if (exist1 == false)
                    {
                        db.users.Add(us);
                        db.SaveChanges();
                        ModelState.Clear();
                        ViewBag.Message = us.firstname + " " + us.lastname + " " + "has successfully registered";
                        return RedirectToAction("LoggedIn");
                    }
                    if (exist1 == true)
                    {
                        ModelState.AddModelError("EMAILEXIST", "email already exists");
                    }


                }

                
            }

            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(users us)
        {
            using (Database1Entities2 db = new Database1Entities2())
            {
                var usr = db.users.Single(u => u.email.Equals(us.email) && u.password.Equals(us.password));
                if(usr != null) {
                    mailTable.Add(us.email);
                    Session["SessionID"] = usr.Id.ToString();
                    Session["FirstName"] = usr.firstname.ToString();
                    Session["LastName"] = usr.lastname.ToString();
                    Session["Email"] = usr.email.ToString();
                    Session["Animal"] = usr.animal.ToString();
                    Session["Smoke"] = usr.smoke.ToString();
                    Session["Luggage"] = usr.luggage.ToString();
                    Session["Phone"] = usr.phone.ToString();
                    if (usr.car != null)
                    {
                        Session["Car"] = usr.car.ToString();
                    }
                    else Session["Car"] = null;
                    

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

        public ActionResult Profil()
        {
            if (Session["SessionID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }



    }
}