using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using TravelTrip.BusinessLayer.Concrete;
using TravelTrip.Entity.Concrete;

namespace TravelTrip.Controllers
{
    public class AdminController : Controller
    {
        private BlogManager blogManager = new BlogManager();
        private CommentManager commentManager = new CommentManager();
        private AboutManager aboutManager = new AboutManager();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        //[Authorize]
        public ActionResult Blog()
        {
            var allBlogs = blogManager.List();
            return View(allBlogs);
        }

        [HttpGet]
        public ActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBlog(Blog blog, HttpPostedFileBase file)
        {
            if (blog != null)
            {
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        char ayrac = '.';
                        string extension = Path.GetExtension(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Content/Images/"), file.FileName.Split(ayrac)[0] + extension);
                        file.SaveAs(_path);
                        blog.BlogImage = _path;
                    }
                }

                blog.Date = DateTime.Now;
                blogManager.Insert(blog);
                return RedirectToAction("Blog");
            }
            return null;
        }

        public ActionResult BlogDetail(int? id)
        {
            var blogDetail = blogManager.Find(x => x.Id == id);
            return View(blogDetail);
        }

        [HttpGet]
        public ActionResult BlogEdit(int? id)
        {
            var blogDetail = blogManager.Find(x => x.Id == id);

            if (blogDetail == null)
                return null;

            return View(blogDetail);
        }

        [HttpPost]
        public ActionResult BlogEdit(Blog blog, HttpPostedFileBase file)
        {
            var blogDetail = blogManager.Find(x => x.Id == blog.Id);

            if (blogDetail == null)
                return null;

            blogDetail.Title = blog.Title;
            blogDetail.Description = blog.Description;
            blogDetail.Date = DateTime.Now;

            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    char ayrac = '.';
                    string extension = Path.GetExtension(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/Images/"), file.FileName.Split(ayrac)[0] + extension);
                    file.SaveAs(_path);
                    blogDetail.BlogImage = _path;
                }
            }

            return RedirectToAction("Blog");
        }

        public ActionResult BlogDelete(Blog b)
        {
            var blog = blogManager.Find(x => x.Id == b.Id);
            blogManager.Delete(blog);
            return RedirectToAction("Blog");
        }

        public ActionResult CommentList()
        {
            var commentList = commentManager.List();
            return View(commentList);
        }

        public ActionResult CommentDelete(int? id)
        {
            var getComment = commentManager.Find(x=>x.Id == id);
            commentManager.Delete(getComment);
            return RedirectToAction("CommentList");
        }

        [HttpGet]
        public ActionResult CommentEdit(int? id)
        {
            var commentDetail = commentManager.Find(x=>x.Id == id);
            return View(commentDetail);
        }

        [HttpPost]
        public ActionResult CommentEdit(Comments comments)
        {
            var commentDetail = commentManager.Find(x => x.Id == comments.Id);
            commentDetail.Comment = comments.Comment;
            commentManager.Update(commentDetail);
            return RedirectToAction("CommentList");
        }

        public ActionResult About()
        {
            var about = aboutManager.List();
            return View(about);
        }

        public ActionResult AboutDelete(int? id)
        {
            var about = aboutManager.Find(x=>x.Id == id);
            int isDelete = aboutManager.Delete(about);
            return RedirectToAction("About");
        }

        [HttpGet]
        public ActionResult AboutEdit(int? id)
        {
            var about = aboutManager.Find(a => a.Id == id);
            return View(about);
        }

        [HttpPost]
        public ActionResult AboutEdit(About about, HttpPostedFileBase file)
        {
            var aboutDetail = aboutManager.Find(a => a.Id == about.Id);
            aboutDetail.Description = about.Description;

            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    char ayrac = '.';
                    string extension = Path.GetExtension(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/Images/"), file.FileName.Split(ayrac)[0] + extension);
                    file.SaveAs(_path);
                    aboutDetail.ImageUrl = _path;
                }
            }

            aboutManager.Update(aboutDetail);
            return RedirectToAction("About");
        }
    }
}