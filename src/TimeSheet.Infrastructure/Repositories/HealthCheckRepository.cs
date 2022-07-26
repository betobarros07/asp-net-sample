using Microsoft.Data.SqlClient;
using TimeSheet.Domain.Repositories;
using TimeSheet.Domain.Settings;
using Dapper;

namespace TimeSheet.Infrastructure.Repositories;

public class HealthCheckRepository : IHealthCheckRepository
{
    private readonly string _sqlConnectionString;

    public HealthCheckRepository(SqlConnectionStringSettings sqlConnectionStringSettings)
    {
        _sqlConnectionString = sqlConnectionStringSettings.ConnectionString;
    }

    public async Task<bool> DatabaseHealthCheck()
    {
        using SqlConnection connection = new(_sqlConnectionString);
        return await connection.QueryFirstOrDefaultAsync<bool>("SELECT 1;");
    }
}