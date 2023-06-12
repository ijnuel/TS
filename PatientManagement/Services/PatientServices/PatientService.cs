using AutoMapper;
using Core.Entities;
using Core.Helpers;
using Repositories.BaseRepositories;
using Repositories.PatientRepositories;
using Services.BaseServices;
using Services.Models.PatientRequest;

namespace Services.PatientServices
{
    public class PatientService : BaseService, IPatientService
    {
        private readonly IPatientRepository _patientRepo;
        private readonly IMapper _mapper;
        public PatientService(IPatientRepository patientRepo, IMapper mapper) : base(patientRepo, mapper)
        {
            _patientRepo = patientRepo;
            _mapper = mapper;
        }

        public async Task<PatientDto> GetByPatientId(string patientId)
        {
            Patient result = await _patientRepo.GetByPatientId(patientId);
            return _mapper.Map<PatientDto>(result);
        }
    }
}
