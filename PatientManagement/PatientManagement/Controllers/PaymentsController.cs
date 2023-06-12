using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.PaymentServices;
using System.Net;
using Services.Models.PaymentRequest;
using Core.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : BaseEntityController<PaymentDto, Payment, CreatePaymentRequest, UpdatePaymentRequest>
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService) : base(paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Result<List<PaymentDto>>), 200)]
        public async Task<IActionResult> GetByPatientId(Guid patientId, DateTime startDate, DateTime endDate)
        {
            try
            {
                List<PaymentDto> result = await _paymentService.GetByPatientId(patientId, startDate, endDate);
                if (result == null)
                {
                    return NotFound(Result<List<PaymentDto>>.Failure());
                }
                return Ok(Result<List<PaymentDto>>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(Result<List<PaymentDto>>.Exception(ex));
            }
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Result<double>), 200)]
        public async Task<IActionResult> GetPatientTotalPayment(Guid patientId, DateTime startDate, DateTime endDate)
        {
            try
            {
                double result = await _paymentService.GetPatientTotalPayment(patientId, startDate, endDate);
                return Ok(Result<double>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(Result<double>.Exception(ex));
            }
        }
    }
}
