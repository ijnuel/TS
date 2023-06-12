using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data.ApplicationDbContext;
using Core.Entities;
using Core.Helpers;
using Repositories.BaseRepositories;

namespace Repositories.PaymentRepositories
{
    public class PaymentRepository : BaseRepository, IPaymentRepository
    {
        private readonly IApplicationDbContext _dbContext;
        public PaymentRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Payment>> GetByPatientId(Guid patientId, DateTime startDate, DateTime endDate)
        {
            string tableName = EntityHelper.GetTableName<Payment>();

            QueryBuilder query = new QueryBuilder($"Select *")
                .From(tableName)
                .Where("PatientId", patientId.ToString());

            query.And(query.Between("PaymentDate", startDate, endDate));

            var result = await _dbContext.GetMany<Payment>(query?.Build() ?? string.Empty);

            return result;
        }
    }
}
