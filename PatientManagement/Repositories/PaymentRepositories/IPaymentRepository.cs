using Core.Entities;
using Repositories.BaseRepositories;

namespace Repositories.PaymentRepositories
{
    public interface IPaymentRepository : IBaseRepository
    {
        Task<List<Payment>> GetByPatientId(Guid patientId, DateTime startDate, DateTime endDate);
    }
}