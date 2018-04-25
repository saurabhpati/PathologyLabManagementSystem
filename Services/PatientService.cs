using Models;
using Repositories;
using System;

namespace Services
{
    public interface IPatientService
    {
        ServiceResponse AddPatientDetails(Patient patient);
    }
    public class PatientService : IPatientService
    {
        public PatientService(IPatientRepository patientRepository)
        {
            PatientRepo = patientRepository;
        }
        protected internal IPatientRepository PatientRepo;

        public ServiceResponse AddPatientDetails(Patient patient)
        {
            ServiceResponse response = new ServiceResponse()
            {
                Status = StatusType.Failure
            };
            try
            {
                response.Status = (PatientRepo.AddPatient(patient) == true) ? StatusType.Success : StatusType.Failure;
            }
            catch (Exception ex)
            {
                response.Error = ex;
            }
            return response;
        }
    }
}
