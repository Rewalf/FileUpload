using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }
        public ActionResult PostBack()
        {
            ViewBag.Title = "PostBack";
            return View();
        }
        public ActionResult Ajax()
        {
            ViewBag.Title = "Ajax";
            return View();
        }
    }
}
