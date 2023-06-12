using Services.BaseServices;
using Services.Models.PatientRequest;

namespace Services.PatientServices
{
    public interface IPatientService : IBaseService
    {
        Task<PatientDto> GetByPatientId(string patientId);
    }
}