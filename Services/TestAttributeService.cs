using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITestAttributeService
    {
        ServiceResponse AddAttributes(IEnumerable<TestAttribute> Obj);
    }

    public class TestAttributeService : ITestAttributeService
    {
        #region Constructor
        public TestAttributeService(ITestAttributeRepository testAttributeRepository)
        {
            TestAttributeRepo = testAttributeRepository;
        }
        #endregion

        #region Dependencies
        protected readonly ITestAttributeRepository TestAttributeRepo;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public ServiceResponse AddAttributes(IEnumerable<TestAttribute> Obj)
        {
            ServiceResponse response = new ServiceResponse()
            {
                Status = StatusType.Failure
            };
            try
            { 
            if (TestAttributeRepo.AddAttributes(Obj))
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
    }
}
