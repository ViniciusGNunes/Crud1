using Crud1.Data;
using Microsoft.AspNetCore.Mvc;

namespace Crud1.Controllers;

[ApiController]
public class UserController:ControllerBase
{
    [HttpGet("/{id:int}")]
    public IActionResult Get([FromServices] AppDbContext context, [FromRoute] int id)
    {
        var user = context.Users.FirstOrDefault(x => x.Id == id);

        return Ok(user);
    }
}