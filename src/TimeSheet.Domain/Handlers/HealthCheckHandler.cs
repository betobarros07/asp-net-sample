using MediatR;
using TimeSheet.Domain.Commands.Input;
using TimeSheet.Domain.Commands.Output;
using TimeSheet.Domain.Repositories;

namespace TimeSheet.Domain.Handlers;

public class HealthCheckHandler : IRequestHandler<HealthCheckGetCommand, HealthCheckGetCommandResult>
{
    private readonly IHealthCheckRepository _healthCheckRepository;

    public HealthCheckHandler(IHealthCheckRepository healthCheckRepository)
    {
        _healthCheckRepository = healthCheckRepository;
    }

    public async Task<HealthCheckGetCommandResult> Handle(HealthCheckGetCommand request, CancellationToken cancellationToken)
    {
        HealthCheckGetCommandResult result = new();
        try
        {
            result.DatabaseAccess = await _healthCheckRepository.DatabaseHealthCheck();
        }
        catch
        {
            result.DatabaseAccess = false;
        }
        
        return await Task.FromResult(result);
    }
}
