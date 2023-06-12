using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.PatientServices;
using System.Net;
using Services.Models.PatientRequest;
using Core.Entities;
using Services.Models.PatientRequest;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : BaseEntityController<PatientDto, Patient, CreatePatientRequest, UpdatePatientRequest>
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService) : base(patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Result<PatientDto>), 200)]
        public async Task<IActionResult> GetByPatientId(string patientId)
        {
            try
            {
                PatientDto result = await _patientService.GetByPatientId(patientId);
                if (result == null)
                {
                    return NotFound(Result<List<PatientDto>>.Failure());
                }
                return Ok(Result<PatientDto>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(Result<PatientDto>.Exception(ex));
            }
        }
    }
}
