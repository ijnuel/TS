using Services.BaseServices;
using Services.Models.PaymentRequest;

namespace Services.PaymentServices
{
    public interface IPaymentService : IBaseService
    {
        Task<List<PaymentDto>> GetByPatientId(Guid patientId, DateTime startDate, DateTime endDate);
        Task<double> GetPatientTotalPayment(Guid patientId, DateTime startDate, DateTime endDate);
    }
}