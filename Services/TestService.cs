using Models;
using Repositories;

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
            ServiceResponse<int> response = new ServiceResponse<int>();

            return response;
        }
    }
}
