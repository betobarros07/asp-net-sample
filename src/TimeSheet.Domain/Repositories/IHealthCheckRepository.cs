namespace TimeSheet.Domain.Repositories;

public interface IHealthCheckRepository
{
    Task<bool> DatabaseHealthCheck();
}