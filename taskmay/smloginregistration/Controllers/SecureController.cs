using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace smloginregistration.Controllers
{
    public class SecureController : Controller
    {
       
        public ActionResult Welcome()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login","Home");
            }
           
        }
    }
}