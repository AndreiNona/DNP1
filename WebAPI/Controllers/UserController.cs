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
    [Route("{accountName}")]
    public async Task<ActionResult<User>> GetUserByUsername([FromRoute] string accountName)
    {
        try
        {
            Console.WriteLine("Searching for user: "+accountName); //Console line
            User u = await _userService.GetUserByUsername(accountName);
            return Ok(u);
        }
        catch (Exception e)
        {
            Console.WriteLine(e); //Console line
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("{id}/ID")]
    public async Task<ActionResult<User>> GetUserById([FromRoute] int id)
    {
        try
        {
            Console.WriteLine("Searching for user: "+id); //Console line
            User u = await _userService.GetUserById(id);
            return Ok(u);
        }
        catch (Exception e)
        {
            Console.WriteLine(e); //Console line
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost]
    [Route("Add")]
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
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<String>> DeleteUser([FromRoute] int id)
    {
        try
        {
            await _userService.DeleteAsync(id);
            return Ok("User " + id + " successfully deleted");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPatch]
    [Route("update")]
    public async Task<ActionResult<User>> UpdateAsync([FromBody] User u)
    {
        try
        {
            await _userService.UpdateAsync(u);
            return Ok("User " + u.id + " successfully updated");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

}