using Models;
using Repositories;
using System;
using System.Collections.Generic;

namespace Services
{
    public interface ITestService
    {
        ServiceResponse<int> AddTest(Test tstObj);
        ServiceResponse<List<Test>> GetAllTest();
        ServiceResponse<Test> GetTest(int id);
        ServiceResponse<List<TestAttribute>> GetTestAttributes(int testId);
        ServiceResponse EditTest(Test tst);
        ServiceResponse<TestDetailsViewModel> GetTestDetails(int id);
    }

    public class TestService : ITestService
    {
        public TestService(ITestRepository testRepository, ITestAttributeRepository testAttrRepository)
        {
            TestRepo = testRepository;
            TestAtttrRepo = testAttrRepository;
        }

        protected readonly ITestRepository TestRepo;
        protected readonly ITestAttributeRepository TestAtttrRepo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tstObj"></param>
        /// <returns>ServiceResponse<int></returns>
        public ServiceResponse<int> AddTest(Test tstObj)
        {
            ServiceResponse<int> response = new ServiceResponse<int>()
            {
                Status = StatusType.Failure
            };

            try
            {
                response.Data = TestRepo.AddTest(tstObj);
                response.Status = StatusType.Success;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.Error = ex;
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>ServiceResponse<List<Test>></returns>
        public ServiceResponse<List<Test>> GetAllTest()
        {
            ServiceResponse<List<Test>> response = new ServiceResponse<List<Test>>()
            {
                Data = new List<Test>(),
                Status = StatusType.Failure
            };

            try
            {
                response.Data = TestRepo.GetAllTest();
                response.Status = StatusType.Success;
            }
            catch (Exception ex)
            {
                response.Error = ex;
            }
            return response;
        }

        public ServiceResponse<Test> GetTest(int id)
        {
            ServiceResponse<Test> response = new ServiceResponse<Test>()
            {
                Status = StatusType.Failure,
                Data = new Test()
            };

            try
            {
                response.Data = TestRepo.GetTest(id);
                response.Status = StatusType.Success;
            }
            catch (Exception ex)
            {
                response.Error = ex;
            }
            return response;
        }


        public ServiceResponse<List<TestAttribute>> GetTestAttributes(int testId)
        {
            ServiceResponse<List<TestAttribute>> response = new ServiceResponse<List<TestAttribute>>()
            {
                Status = StatusType.Failure,
                Data = new List<TestAttribute>()
            };

            try
            {
                response.Data = TestRepo.GetTestAttributes(testId);
                response.Status = StatusType.Success;
            }
            catch (Exception ex)
            {
                response.Error = ex;
            }
            return response;
        }

        public ServiceResponse EditTest(Test tst)
        {
            ServiceResponse response = new ServiceResponse()
            {
                Status = StatusType.Failure
            };
            try
            {
                if (TestRepo.EditTest(tst))
                {
                    response.Status = StatusType.Success;
                }
            }
            catch(Exception ex)
            {
                response.Error = ex;
            }
            return response;
        }

        public ServiceResponse<TestDetailsViewModel> GetTestDetails(int id)
        {
            ServiceResponse<TestDetailsViewModel> response = new ServiceResponse<TestDetailsViewModel>()
            {
                Data = new TestDetailsViewModel(),
                Status = StatusType.Success
            };
            try
            {
                var testObj = TestRepo.GetTest(id);
                var lstAttrs = TestRepo.GetTestAttributes(id);
                response.Data.TestId = testObj.Id;
                response.Data.TestName = testObj.Name;
                response.Data.TestType = testObj.Type;
                response.Data.LstTestAttr = lstAttrs;
                response.Status = StatusType.Success;
            }
            catch (Exception ex)
            {
                response.Error = ex;
            }
            return response;
        }
    }
}
