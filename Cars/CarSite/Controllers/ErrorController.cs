using System.Web.Mvc;

namespace CarSite.Controllers
{
    public class ErrorController : Controller
    {

        public ActionResult Index()
        {
            return View("Error");
        }
        // GET: Error
        public ActionResult NotFound()
        {
            return View();
        }
    }
}