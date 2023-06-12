using Core.Entities;
using Repositories.BaseRepositories;

namespace Repositories.PatientRepositories
{
    public interface IPatientRepository : IBaseRepository
    {
        Task<Patient> GetByPatientId(string patientId);
    }
}