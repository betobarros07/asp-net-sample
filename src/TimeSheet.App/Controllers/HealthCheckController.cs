using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TimeSheet.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HealthCheckController : ControllerBase
{
    public HealthCheckController()
    {
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return await Task.FromResult(NoContent());
    }
}
