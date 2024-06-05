using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace TesteJuntoSeguros.Infrastructure.CommomContext
{
    public class DataContext
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new MySqlConnection(_connectionString);

        public IDbCommand CreateCommand() => new MySqlCommand();
    }
}
