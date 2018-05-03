using System.Collections.Generic;
using System.Web.Mvc;
using Models;
using PathologyLabManagementSystem.Areas.User.ViewModels;
using Services;

namespace PathologyLabManagementSystem.Areas.User.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

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
            var serviceResponse = _patientService.AddPatientDetails(patient);
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