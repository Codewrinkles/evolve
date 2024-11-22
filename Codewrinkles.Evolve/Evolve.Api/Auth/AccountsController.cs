using Microsoft.AspNetCore.Mvc;

namespace Evolve.Api.Auth;

[ApiController]
public class AccountsController : ControllerBase
{

    [HttpPost]
    [Route("api/signup")]
    public async Task<IActionResult> Register()
    {
        Console.WriteLine("Registering user");
        return Ok();
    }
}
