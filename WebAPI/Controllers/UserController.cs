using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    [Route("users")]
    public async Task<ActionResult<User>> GetAllUsers()
    {
        try
        {
            ICollection<User> users = await _userService.GetAsync();
            return Ok(users);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    [HttpGet]
    [Route("{username}")]
    public async Task<ActionResult<User>> GetUser([FromRoute] string username)
    {
        try
        {
            Console.WriteLine("Searching for user: "+username);
            User u = await _userService.GetUser(username);
            return Ok(u);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser([FromBody] User u)
    {
        try
        {
            await _userService.AddUserAsync(u);
            return Created($"/users/{u.username}",u);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    
}