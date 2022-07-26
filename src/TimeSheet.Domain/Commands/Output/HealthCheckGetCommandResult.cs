namespace TimeSheet.Domain.Commands.Output;

public class HealthCheckGetCommandResult
{
    public bool DatabaseAccess { get; set; } = default;
}
