using Crud1.Data;
using Crud1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crud1.Controllers;

[ApiController]
[Route("")]
public class UserController:ControllerBase
{
    //CRUD - CREATE READ UPDATE DELETE
    //BREAD - BROWSE READ EDIT ADD DELETE

    [HttpGet("user")]
    public IActionResult GetAllUsers([FromServices] AppDbContext context) 
    {
        var users = context.Users.ToList();

        return Ok(users);
    }
    
    [HttpGet("user/{id:int}")]
    public IActionResult GetOneUser([FromServices] AppDbContext context, [FromRoute] int id)
    {
        var user = context.Users.FirstOrDefault(x => x.Id == id);

        return Ok(user);
    }

    [HttpPost("user")]
    public IActionResult AddUser([FromServices] AppDbContext context, [FromBody] UserModel user)
    {
        context.Users.Add(user);
        context.SaveChanges();

        return Ok(user);
    }

    [HttpPut("user/{id:int}")]
    public IActionResult EditUser([FromServices] AppDbContext context, [FromBody] UserModel model, [FromRoute] int id)
    {
        var user = context.Users.FirstOrDefault(x => x.Id == id);
        user.Salary = model.Salary;
        user.Email = model.Email;
        user.Name = model.Name;

        context.Users.Update(user);
        context.SaveChanges();

        return Ok(user);
    }

    [HttpDelete("user/{id:int}")]
    public IActionResult DeleteUser([FromServices] AppDbContext context, [FromRoute]int id)
    {
        var user = context.Users.SingleOrDefault(x => x.Id == id);
        context.Users.Remove(user);
        context.SaveChanges();

        return Ok();
    }


}