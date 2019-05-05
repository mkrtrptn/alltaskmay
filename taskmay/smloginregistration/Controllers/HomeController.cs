using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smloginregistration.Models;

namespace smloginregistration.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin u)
        {
            if (ModelState.IsValid)
            {
                using (UserEntities db = new UserEntities())
                {
                    var user = db.users.Where(a=>a.Username.Equals(u.username) && a.Password.Equals(u.password)).FirstOrDefault();
                    if(user != null)
                    {
                        Session["UserId"] = user.UserId.ToString();
                        Session["Name"] = user.Fullname.ToString();
                        return RedirectToAction("Welcome","Secure");
                    }
                }
            }

            ViewBag.msg = "Invalid Credentials";
            return View(u);
        }

        public ActionResult Register()
        {
            return View();
        }
      
        [HttpPost]
        public  ActionResult Register(user u)
        {

            if(ModelState.IsValid)
            {
                using (UserEntities dc = new UserEntities())
                {
                    dc.users.Add(u);
                    dc.SaveChanges();
                    ModelState.Clear();
                    u = null;
                    ViewBag.success = "Registration Successfull";
                }
            }
            ViewBag.msg = "Invalid Request";
            return View(u);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return View();
        }

    }
}