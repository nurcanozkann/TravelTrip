using System.Linq;
using System.Web.Mvc;
using TravelTrip.BusinessLayer.Concrete;
using TravelTrip.Entity.Concrete;

namespace TravelTrip.Controllers
{
    public class CommentController : Controller
    {
        private CommentManager commentManager = new CommentManager();

        public ActionResult Index()
        {
            return View();
        }

        
    }
}