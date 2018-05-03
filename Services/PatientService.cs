using System;
using Models;
using Repositories;

namespace Services
{
    public interface IPatientService
    {
        ServiceResponse AddPatientDetails(Patient patient);
    }

    public class PatientService : IPatientService
    {
        private IPatientRepository _patientRepo;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepo = patientRepository;
        }

        public ServiceResponse AddPatientDetails(Patient patient)
        {
            ServiceResponse response = new ServiceResponse()
            {
                Status = StatusType.Failure
            };

            try
            {
                response.Status = (_patientRepo.AddPatient(patient) == true) ? StatusType.Success : StatusType.Failure;
            }
            catch (Exception ex)
            {
                response.Error = ex;
            }

            return response;
        }
    }
}
