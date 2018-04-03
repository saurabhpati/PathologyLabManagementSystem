using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PathologyLabManagementSystem.Areas.Admin.Controllers
{
    public class PatientController : Controller
    {
        // GET: Admin/Patient
        public ActionResult Index()
        {
            return View();
        }
    }
}