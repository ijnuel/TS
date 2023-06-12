using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.BaseRepositories
{
    public interface IBaseRepository
    {
        Task<List<TEntity>> GetAll<TEntity>();
        Task<TEntity?> GetById<TEntity>(Guid id);
        Task<bool> Insert<TEntity>(List<string> columns, List<List<string>> values);
        Task<bool> Update<TEntity>(Guid id, Dictionary<string, string> columnsValue);
    }
}
