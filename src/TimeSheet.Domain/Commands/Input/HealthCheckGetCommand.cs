using MediatR;
using TimeSheet.Domain.Commands.Output;

namespace TimeSheet.Domain.Commands.Input;

public class HealthCheckGetCommand : IRequest<HealthCheckGetCommandResult>
{
}
