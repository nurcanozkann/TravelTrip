using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.BusinessLayer.Concrete;

namespace TravelTrip.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager();
        // GET: About
        public ActionResult Index()
        {
            var aboutList = aboutManager.List();
            return View(aboutList);
        }
    }
}