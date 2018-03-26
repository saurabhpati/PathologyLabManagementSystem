using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Models;
using PathologyLabManagementSystem.Areas.Admin.ViewModels;

namespace PathologyLabManagementSystem.Areas.Admin.Controllers
{
    public class TestController : Controller
    {
        #region Constructor
        public TestController(ITestService testService, ITestCommentService testCommentService, ITestAttributeService testAttributeService)
        {
            TestService = testService;
            TestCommentService = testCommentService;
            TestAttributeService = testAttributeService;
        }
        #endregion Constructor

        #region dependencies
        protected readonly ITestService TestService;
        protected readonly ITestCommentService TestCommentService;
        protected readonly ITestAttributeService TestAttributeService;
        #endregion

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
            var testServiceResponse = TestService.AddTest(tstObj);

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
            return View();
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


        /// <summary>
        /// For Loading new addTestAttribute Partial view
        /// </summary>
        /// <returns></returns>
        public ActionResult BlankEditorRow()
        {
            return PartialView("AddTestAttributePartial", new TestAttribute());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testAttributes"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddTestAttribute(IEnumerable<TestAttribute> testAttributes)
        {
            foreach(var list in testAttributes)
            {
                list.TestId = (int)Session["tstId"];
            }
            var testAttributeServiceResponse = TestAttributeService.AddAttributes(testAttributes);
            ViewBag.Message = "Test was created successfully";
            return RedirectToAction("AddTest","Test");
        }


    }
}