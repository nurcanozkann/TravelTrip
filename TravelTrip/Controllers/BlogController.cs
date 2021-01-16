using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TravelTrip.BusinessLayer.Concrete;
using TravelTrip.Entity.Concrete;
using TravelTrip.Models;

namespace TravelTrip.Controllers
{
    public class BlogController : Controller
    {
        private BlogManager blogManager = new BlogManager();
        private CommentManager commentManager = new CommentManager();

        private CommentBlogViewModel cb = new CommentBlogViewModel();

        // GET: Blog
        public ActionResult Index()
        {
            cb.Blog = blogManager.List();
            cb.LastBlogs = blogManager.List().Take(3);
            cb.LastComments = commentManager.List().Take(5);
            return View(cb);
        }

        public ActionResult BlogDetail(int? id)
        {
            cb.Blog = blogManager.List(x => x.Id == id);
            cb.Comments = commentManager.List(x => x.BlogId == id);
            cb.LastBlogs = blogManager.List().Take(3);
            cb.LastComments = commentManager.List(x => x.Id == id).Take(5);
            //var blogDetail = blogManager.Find(x => x.Id == id);
            //if (blogDetail == null)
            //    throw new Exception("Kayıt bulunmuyor.");

            return View(cb);
        }

        [HttpPost]
        public ActionResult AddComment(string username, string mail, string comment, int blogId)
        {
            Comments comments = new Comments();
            comments.Username = username;
            comments.Mail = mail;
            comments.Comment = comment;
            comments.BlogId = blogId;
            ViewData["BlogId"] = blogId;

            int insertData = commentManager.Insert(comments);

            return RedirectToAction("Index");
        }
    }
}