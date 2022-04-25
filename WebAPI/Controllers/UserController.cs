using Contracts.Services;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }


    [HttpGet]
    public async Task<ActionResult<ICollection<User>>> GetAll()
    {
        try
        {
            ICollection<User> users = await userService.GetAllUsersAsync();
            return Ok(users);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<User>> AddUser([FromBody] User user)
    {
        try
        {
            User addedUser = await userService.AddUserAsync(user);
            return Created($"/users/{addedUser.username}", addedUser);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("username")]
    public async Task<ActionResult<User>> GetByUsername(string username)
    {
        try
        {
            User user = await userService.GetUserAsync(username);
            return Ok(user);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
}