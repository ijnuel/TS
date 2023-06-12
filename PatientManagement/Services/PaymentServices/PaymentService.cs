using AutoMapper;
using Core.Entities;
using Core.Helpers;
using Repositories.BaseRepositories;
using Repositories.PaymentRepositories;
using Services.BaseServices;
using Services.Models.PaymentRequest;

namespace Services.PaymentServices
{
    public class PaymentService : BaseService, IPaymentService
    {
        private readonly IPaymentRepository _paymentRepo;
        private readonly IMapper _mapper;
        public PaymentService(IPaymentRepository paymentRepo, IMapper mapper) : base(paymentRepo, mapper)
        {
            _paymentRepo = paymentRepo;
            _mapper = mapper;
        }

        public async Task<List<PaymentDto>> GetByPatientId(Guid patientId, DateTime startDate, DateTime endDate)
        {
            List<Payment> result = await _paymentRepo.GetByPatientId(patientId, startDate, endDate);
            return _mapper.Map<List<PaymentDto>>(result);
        }

        public async Task<double> GetPatientTotalPayment(Guid patientId, DateTime startDate, DateTime endDate)
        {
            return (await GetByPatientId(patientId, startDate, endDate))?.Sum(x => x.Amount) ?? 0;
        }
    }
}
