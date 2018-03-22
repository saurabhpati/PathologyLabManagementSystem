using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Models;

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

        [HttpGet]
        /// <summary>
        /// Loads the view page to add new test!
        /// </summary>
        /// <returns>A view</returns>
        public ActionResult AddTest([Bind(Include = "Name")]Test tstObj)
        {
            ServiceResponse<int> response = new ServiceResponse<int>()
            {
                Status = StatusType.Failure
            };

            if(TestService.)
            return View();
        }

        public ActionResult ViewTests()
        {
            return View();
        }
    }
}