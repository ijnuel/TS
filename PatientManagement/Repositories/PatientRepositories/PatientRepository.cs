using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data.ApplicationDbContext;
using Core.Entities;
using Core.Helpers;
using Repositories.BaseRepositories;

namespace Repositories.PatientRepositories
{
    public class PatientRepository : BaseRepository, IPatientRepository
    {
        private readonly IApplicationDbContext _dbContext;
        public PatientRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Patient> GetByPatientId(string patientId)
        {
            string tableName = EntityHelper.GetTableName<Patient>();

            QueryBuilder query = new QueryBuilder($"Select top 1 *")
                .From(tableName)
                .Where("patientId", patientId);

            var result = await _dbContext.GetOne<Patient>(query?.Build() ?? string.Empty);

            return result;
        }
    }
}
