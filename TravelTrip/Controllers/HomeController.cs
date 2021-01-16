using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.BusinessLayer.Concrete;

namespace TravelTrip.Controllers
{
    public class HomeController : Controller
    {
        BlogManager blogManager = new BlogManager();
        public ActionResult Index()
        {
            var blogs = blogManager.List().Take(4);
            return View(blogs);
        }
        public PartialViewResult PartialBlogListLeft()
        {
            var lastTwoBlog = blogManager.List().OrderByDescending(x => x.Date).Take(2);
            return PartialView(lastTwoBlog);
        }

        public PartialViewResult PartialBlogListRight()
        {
            var lastOneBlog = blogManager.List().OrderBy(x => x.Date).Take(1);
            return PartialView(lastOneBlog);
        }

        public PartialViewResult PartialFirstTen()
        {
            var lastTenBlog = blogManager.List().Take(10);
            return PartialView(lastTenBlog);
        }

        public PartialViewResult PartialBestPlacesLeft()
        {
            var bestPlacesBlog = blogManager.List().Take(3);
            return PartialView(bestPlacesBlog);
        }

        public PartialViewResult PartialBestPlacesRight()
        {
            var bestPlacesBlog = blogManager.List().OrderByDescending(x=>x.Date).Take(3);
            return PartialView(bestPlacesBlog);
        }
    }
}