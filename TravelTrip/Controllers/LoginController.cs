using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTrip.BusinessLayer.Concrete;
using TravelTrip.Entity.Concrete;

namespace TravelTrip.Controllers
{
    public class LoginController : Controller
    {
        AdminManager adminManager = new AdminManager();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var infos=adminManager.Find(x => x.Username == admin.Username && x.Password == admin.Password);
            if (infos != null)
            {
                FormsAuthentication.SetAuthCookie(infos.Username, false);
                Session["Username"] = infos.Username;
                return RedirectToAction("Index", "Admin");
            }
            else
                return View();
        
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Login");
        }
    }
}