using Core.Data.ApplicationDbContext;
using Core.Entities;
using Core.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.BaseRepositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public BaseRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TEntity>> GetAll<TEntity>()
        {
            string tableName = EntityHelper.GetTableName<TEntity>();

            QueryBuilder query = new QueryBuilder($"Select *")
                .From(tableName);

            var result = await _dbContext.GetMany<TEntity>(query?.Build() ?? string.Empty);

            return result;
        }

        public async Task<TEntity?> GetById<TEntity>(Guid id)
        {
            string tableName = EntityHelper.GetTableName<TEntity>();

            QueryBuilder query = new QueryBuilder($"Select top 1 *")
                .From(tableName)
                .Where("id", id.ToString());

            var result = await _dbContext.GetOne<TEntity>(query?.Build() ?? string.Empty);

            return result;
        }

        public async Task<bool> Insert<TEntity>(List<string> columns, List<List<string>> values)
        {
            string tableName = EntityHelper.GetTableName<TEntity>();

            QueryBuilder query = new QueryBuilder()
                .InsertInto(tableName, columns, values);

            await _dbContext.RunCommand(query?.Build() ?? string.Empty);

            return true;
        }

        public async Task<bool> Update<TEntity>(Guid id, Dictionary<string, string> columnsValue)
        {
            string tableName = EntityHelper.GetTableName<TEntity>();

            QueryBuilder query = new QueryBuilder()
                .Update(tableName)
                .Set(columnsValue)
                .Where("id", id.ToString());

            await _dbContext.RunCommand(query?.Build() ?? string.Empty);

            return true;
        }
    }
}
