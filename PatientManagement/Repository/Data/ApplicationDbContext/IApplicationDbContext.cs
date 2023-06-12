using Core.Models.Configurations;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;

namespace Core.Data.ApplicationDbContext
{
    public interface IApplicationDbContext
    {
        Task<TEntity?> GetOne<TEntity>(string query);
        Task<List<TEntity>> GetMany<TEntity>(string query);
        Task<int> RunCommand(string query);
    }
}
