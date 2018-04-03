using Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface IPatientRepository
    {

    }
    public class PatientRepository : IPatientRepository
    {
        public ServiceResponse<List<Patient>> GetAllPatients()
        { }
    }
}
