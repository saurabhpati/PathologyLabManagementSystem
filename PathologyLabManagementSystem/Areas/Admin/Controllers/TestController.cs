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
            List<TestAttribute> moreTest = new List<TestAttribute>
            {
                new TestAttribute(){ TestId=(int)Session["tstId"] },
                new TestAttribute(){ TestId=(int)Session["tstId"] },
                null
            };

            TestAttributeViewModel obj = new TestAttributeViewModel()
            {
                LstAttr = moreTest
            };
            obj.LstAttr.RemoveAll(item => item == null);
            return View(obj);
        }

        

        public ActionResult AddTestAttributePartial()
        {
            return PartialView(new TestAttribute());
        }

        [HttpPost]
        public ActionResult AddTestAttribute(List<TestAttribute> lstAttributes)
        {
            var lstAttr = lstAttributes;
            foreach (var lst in lstAttributes)
            {
                int count = 0;
                count++;
            }
            return View();
        }


    }
}