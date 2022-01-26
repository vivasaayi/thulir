

using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace Thulir.Core.Dals
{
    public class PostgresDal
    {
        private static PostgresDal Instance;
        private static PostgresConfig _postgresConfig;
        
        private readonly static object _lock = new object();

        public static void Init(PostgresConfig config)
        {
            _postgresConfig = config;
        }
        
        public static PostgresDal GetInstance()
        {
            lock (_lock)
            {
                if (Instance == null)
                {
                    Instance = new PostgresDal();
                }
            }

            return Instance;
        }

        public static IDbConnection GetConnection()
        {
            IDbConnection connection = new NpgsqlConnection(_postgresConfig.GetConnectionString());
            connection.Open();
            return connection;
        }

        public async Task<IEnumerable<T>> ExecuteQuery<T>(string command)
        {
            var result   = await GetConnection().QueryAsync<T>(command);
            return result;
        }
    }
}