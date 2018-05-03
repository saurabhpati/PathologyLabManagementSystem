using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Models;
using PathologyLabManagementSystem.Areas.Admin.ViewModels;
using Services;

namespace PathologyLabManagementSystem.Areas.Admin.Controllers
{
    //[Authorize]
    public class TestController : Controller
    {
        private readonly ITestService _testService;
        private readonly ITestCommentService _testCommentService;
        private readonly ITestAttributeService _testAttributeService;

        #region Constructor

        public TestController(ITestService testService, ITestCommentService testCommentService, ITestAttributeService testAttributeService)
        {
            _testService = testService;
            _testCommentService = testCommentService;
            _testAttributeService = testAttributeService;
        }

        #endregion Constructor

        // GET: Admin/Test
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Loads the view page to add new test!
        /// </summary>
        /// <returns>A view</returns>
        /// [HttpGet]
        public ActionResult AddTest()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tstObj"></param>
        /// <returns></returns>
        [HttpPost]        
        public ActionResult AddTest([Bind(Include = "Name,Type")]Test tstObj)
        {
            var testServiceResponse = _testService.AddTest(tstObj);

            if (testServiceResponse.Status == StatusType.Success)
            {
                tstObj.Id = testServiceResponse.Data;
                Session["tstId"] = tstObj.Id;
                return RedirectToAction("AddTestAttribute");
            }            
            return View();
        }

        public ActionResult ViewTests()
        {
            List<Test> lstTest = new List<Test>();
            var serviceResponse = _testService.GetAllTest();
            if (serviceResponse.Status == StatusType.Success)
            {
                lstTest = serviceResponse.Data;
            }
            else
            {
                lstTest.Add(
                    new Test() { Name = serviceResponse.Error.Message }
                );
            }
            ViewBag.Message = TempData["Message"];
            return View(lstTest);
        }

        public ActionResult AddTestAttributeEditor()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstAttributes"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddTestAttributeEditor(List<TestAttribute> lstAttributes)
        {
            var lst = lstAttributes;
            //int tstId = tstAtribtObj.TestId;
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddTestAttribute()
        {
            List<TestAttribute> lst = new List<TestAttribute>
            {
                new TestAttribute(){ TestId=(int)Session["tstId"]}
            };
            TestAttributeViewModel obj = new TestAttributeViewModel
            {
                LstAttr = lst
            };
            return View(obj);
        }

        // <summary>
        /// 
        /// </summary>
        /// <param name="testAttributes"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddTestAttribute(IEnumerable<TestAttribute> testAttributes)
        {
            foreach (var list in testAttributes)
            {
                list.TestId = (int)Session["tstId"];
            }
            var testAttributeServiceResponse = _testAttributeService.AddAttributes(testAttributes);
            TempData["Message"] = "Test was created successfully";
            return RedirectToAction("AddTest", "Test");
        }

        [HttpGet]
        public ActionResult EditTest(int id)
        {
            EditTestViewModel tst = new EditTestViewModel();
            Session["tstId"] = id;
            var serviceResponse = _testService.GetTest(id);
            if(serviceResponse.Status==StatusType.Success)
            {
                tst.Id = serviceResponse.Data.Id;
                tst.Name = serviceResponse.Data.Name;
                tst.Type = serviceResponse.Data.Type;
            }
            return View(tst);
        }

        [HttpPost]
        public ActionResult EditTest([Bind(Include = "Name,Type,Id")]Test tst)
        {
            var serviceResponse = _testService.EditTest(tst);

            if (serviceResponse.Status == StatusType.Success)
            {
                TempData["Message"] = $"updated {tst.Name} successfully!";
            }
            return RedirectToAction("ViewTests", "Test");
        }

        [HttpGet]
        public ActionResult EditAttributes(int id)
        {
            int testId = id;
            var serviceResponse = _testService.GetTestAttributes(testId);
            TestAttributeViewModel obj = new TestAttributeViewModel();
            
            if (serviceResponse.Status == StatusType.Success)
            {
                obj.LstAttr = serviceResponse.Data;
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult EditAttributes(IEnumerable<TestAttribute> testAttributes)
        {
            List<TestAttribute> lstTstAttr = testAttributes.ToList();
            foreach (var testAttr in lstTstAttr)
            {
                testAttr.TestId = (int)Session["tstId"];
            }
            var serviceResponse = _testAttributeService.EditTestAttribute(lstTstAttr);
            if (serviceResponse.Status == StatusType.Success)
            {
                TempData["Message"] = "Attributes were successfully edited!";
            }
            return RedirectToAction("ViewTests","Test");
        }

        /// <summary>
        /// To get the details of a selected test
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TestDetails(int id)
        {
            var details = _testService.GetTestDetails(id);
            if (details.Status == StatusType.Success)
            {
                return View(details.Data);
            }
            else
            {
                TempData["Message"] = "Failed to load Details!";
                return RedirectToAction("ViewTests", "Test");
            }
        }

        /// <summary>
        /// For Loading new addTestAttribute Partial view
        /// </summary>
        /// <returns></returns>
        public ActionResult BlankEditorRow()
        {
            return PartialView("TestAttributePartial", new TestAttribute());
        }
    }
}