﻿using System;
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

        [HttpGet]
        /// <summary>
        /// Loads the view page to add new test!
        /// </summary>
        /// <returns>A view</returns>
        public ActionResult AddTest()
        {
            return View();
        }

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

        [HttpPost]
        public ActionResult AddTestAttributeEditor(List<TestAttribute> lstAttributes)
        {
            var lst = lstAttributes;
            //int tstId = tstAtribtObj.TestId;
            return View();
        }

        [HttpGet]

        public ActionResult AddTestAttribute()
        {
            List<TestAttribute> lst = new List<TestAttribute>
            {
                new TestAttribute(){ TestId=1}
            };
            TestAttributeViewModel obj = new TestAttributeViewModel();
            obj.LstAttr = lst;

            return View(obj);

        }



        public ActionResult BlankEditorRow()
        {
            return PartialView("AddTestAttributePartial", new TestAttribute());
        }

        [HttpPost]
        public ActionResult AddTestAttribute(IEnumerable<TestAttribute> testAttributes)
        {
            var lstAttr = testAttributes;
            foreach (var lst in testAttributes)
            {
                int count = 0;
                count++;
            }
            return View();
        }


    }
}