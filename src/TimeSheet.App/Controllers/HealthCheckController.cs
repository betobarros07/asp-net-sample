using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Domain.Commands.Input;

namespace TimeSheet.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HealthCheckController : ControllerBase
{
    private IMediator _mediatR;

    public HealthCheckController(IMediator mediatR)
    {
        _mediatR = mediatR;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        HealthCheckGetCommand command = new();
        var result = await _mediatR.Send(command);
        if (result.DatabaseAccess)
        {
            return NoContent();
        }

        return StatusCode(((int)HttpStatusCode.ServiceUnavailable));
    }
}
