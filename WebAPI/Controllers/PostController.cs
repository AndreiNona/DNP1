using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }
    
    [HttpGet]
    public async Task<ActionResult<ICollection<Post>>> GetAllPosts()
    {
        try
        {
            ICollection<Post> posts = await _postService.GetAsync();
            return Ok(posts);

        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Post>> GetPost([FromRoute] int id)
    {
        try
        {
            Post p= await _postService.GetPost(id);
            return Ok(p);

        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost([FromBody] Post post)
    {
        try
        {
            await _postService.AddAsync(post);
            return Created($"/posts/{post.ID}",post);

        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPatch]
    [Route("{id:int}")]
    public async Task<ActionResult<String>> UpdatePost([FromBody] Post post)
    {
        try
        {
            await _postService.UpdateAsync(post);
            return Ok("Post "+post.ID+" successfully updated");

        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
}