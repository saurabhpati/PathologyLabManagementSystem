using Models;
using Repositories;
using System;

namespace Services
{
    public interface ITestService
    {
        ServiceResponse<int> AddTest(Test tstObj);
    }

    public class TestService : ITestService
    {
        public TestService(ITestRepository testRepository)
        {
            TestRepo = testRepository;
        }

        protected readonly ITestRepository TestRepo;

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
    }
}
