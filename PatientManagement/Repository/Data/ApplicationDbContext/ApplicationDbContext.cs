using Core.Entities;
using Core.Helpers;
using Core.Models.Configurations;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;
using System.Diagnostics.Metrics;

namespace Core.Data.ApplicationDbContext
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        private readonly string _connectionString;
        public ApplicationDbContext(IOptions<ConnectionStrings> options)
        {
            _connectionString = options.Value.DefaultConnection;
        }

        public async Task<TEntity?> GetOne<TEntity>(string query)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    var result = EntityHelper.MapEntity<TEntity>(await command.ExecuteReaderAsync());
                    return result.FirstOrDefault();
                }
            }
        }

        public async Task<List<TEntity>> GetMany<TEntity>(string query)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    var result = EntityHelper.MapEntity<TEntity>(await command.ExecuteReaderAsync());
                    return result;
                }
            }
        }

        public async Task<int> RunCommand(string query)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
