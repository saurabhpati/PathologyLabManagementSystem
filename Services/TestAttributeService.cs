using System;
using System.Collections.Generic;
using Models;
using Repositories;

namespace Services
{
    public interface ITestAttributeService
    {
        ServiceResponse AddAttributes(IEnumerable<TestAttribute> Obj);
        ServiceResponse EditTestAttribute(List<TestAttribute> lstAttr);
    }

    public class TestAttributeService : ITestAttributeService
    {
        private readonly ITestAttributeRepository _testAttributeRepo;

        #region Constructor
        public TestAttributeService(ITestAttributeRepository testAttributeRepository)
        {
            _testAttributeRepo = testAttributeRepository;
        }
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
                if (_testAttributeRepo.AddAttributes(Obj))
                {
                    response.Status = StatusType.Success;
                }
            }
            catch (Exception ex)
            {
                response.Error = ex;
            }

            return response;
        }

        public ServiceResponse EditTestAttribute(List<TestAttribute> lstAttr)
        {
            ServiceResponse response = new ServiceResponse()
            {
                Status = StatusType.Failure
            };

            try
            {
                if (_testAttributeRepo.EditTestAttribute(lstAttr))
                {
                    response.Status = StatusType.Success;
                }
            }
            catch (Exception ex)
            {
                response.Error = ex;
            }

            return response;
        }
    }
}
