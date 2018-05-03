using System.Web.Mvc;

namespace PathologyLabManagementSystem.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Panel()
        {
            return View();
        }
    }
}