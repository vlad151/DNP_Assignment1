using Contracts.Services;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private IPostServices postService;

    public PostController(IPostServices postService)
    {
        this.postService = postService;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Post>>> getAllPostsAsync()
    {
        try
        {
            ICollection<Post> posts = await postService.GetAllPostsAsync();
            return Ok(posts);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("{Id}")]
    public async Task<ActionResult<Post>> GetPostById([FromRoute] string Id)
    {
        try
        {
            Post post = await postService.GetPostAsync(Id);
            return Ok(post);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Post>> AddPostAsync([FromBody] Post post)
    {
        try
        {
            Post addedPost = await postService.CreatePost(post);
            return Created($"/posts/{addedPost.Id}", addedPost);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    [Route("{Id}/comments")]
    public async Task<ActionResult> AddCommentAsync([FromBody] Comment comment, [FromRoute] string Id)
    {
        try
        {
            await postService.AddComment(Id, comment);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    [Route("{Id}/votes")]
    public async Task<ActionResult> AddUpvote([FromBody] Vote vote, [FromRoute] string Id)
    {
        try
        {
             postService.Upvote(Id, vote);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost]
    [Route("{Id}/downvotes")]
    public async Task<ActionResult> AddDownvote([FromBody] Vote vote, [FromRoute] string Id)
    {
        try
        {
            postService.Downvote(Id, vote);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}