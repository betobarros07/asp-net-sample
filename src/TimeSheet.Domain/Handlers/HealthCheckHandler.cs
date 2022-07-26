using MediatR;
using TimeSheet.Domain.Commands.Input;
using TimeSheet.Domain.Commands.Output;

namespace TimeSheet.Domain.Handlers;

public class HealthCheckHandler : IRequestHandler<HealthCheckGetCommand, HealthCheckGetCommandResult>
{
    public async Task<HealthCheckGetCommandResult> Handle(HealthCheckGetCommand request, CancellationToken cancellationToken)
    {
        HealthCheckGetCommandResult result = new();
        return await Task.FromResult(result);
    }
}
