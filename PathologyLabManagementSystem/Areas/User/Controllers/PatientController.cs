using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PathologyLabManagementSystem.Areas.User.ViewModels;
using Models;
using Services;

namespace PathologyLabManagementSystem.Areas.User.Controllers
{
    public class PatientController : Controller
    {
        public PatientController(IPatientService patientService)
        {
            PatientService = patientService;
        }

        protected readonly IPatientService PatientService;
        // GET: User/Patient
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPatient()
        {
            AddPatientViewModel model = new AddPatientViewModel();
            List<SelectListItem> listSx = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Male", Value = "Male" },
                new SelectListItem() { Text = "Female", Value = "Female" },
                new SelectListItem() { Text = "Other", Value = "Other" }
            };
            model.LstSex = listSx;

            List<SelectListItem> listMarStatus = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Married", Value = "Married" },
                new SelectListItem() { Text = "Single", Value = "Single" },
                new SelectListItem() { Text = "Divorced", Value = "Divorced" }
            };
            model.LstMaritalStatus = listMarStatus;

            List<SelectListItem> listBloodGroup = new List<SelectListItem>
            {
                new SelectListItem() { Text = "A+", Value = "A+" },
                new SelectListItem() { Text = "B+", Value = "B+" },
                new SelectListItem() { Text = "O+", Value = "O+" },
                new SelectListItem() { Text = "AB+", Value = "AB+" },
                new SelectListItem() { Text = "A-", Value = "A-" },
                new SelectListItem() { Text = "B-", Value = "B-" },
                new SelectListItem() { Text = "O-", Value = "O-" },
                new SelectListItem() { Text = "AB-", Value = "AB-" }
            };
            model.LstBloodGroup = listBloodGroup;

            return View(model);
        }

        [HttpPost]
        public ActionResult AddPatient([Bind(Include = "FirstName,LastName,Age,Address,Sex,Parent_Spouse_Name,Relation,Email,PhoneNumber,MaritalStatus,BloodGroup")]Patient patient)
        {
            var serviceResponse = PatientService.AddPatientDetails(patient);
            if (serviceResponse.Status == StatusType.Success)
            {
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}