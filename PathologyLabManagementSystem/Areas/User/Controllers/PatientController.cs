using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PathologyLabManagementSystem.Areas.User.Controllers
{
    public class PatientController : Controller
    {
        // GET: User/Patient
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPatient()
        {
            return View();
        }
    }
}