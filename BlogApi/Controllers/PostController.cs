using BlogApi.Models;
using BlogApi.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddNewPost(AddPostDto addPostDto)
        {
            try
            {
                using(var context = new BlogDbConntext())
                {
                    var post = new Post
                    {
                        Category = addPostDto.Category,
                        Description = addPostDto.Description,
                        BloggerId = addPostDto.BloggerId
                    };
                    if (post != null)
                    {
                        context.Post.Add(post);
                        context.SaveChanges();
                        return StatusCode(201, new { Message = "Post created successfully", PostId = post.Id });
                    }
                    return StatusCode(404, new { Message = "Post creation failed" });
                }
            }
            catch (Exception ex)
            {

                return NotFound(new { Message = ex.Message });
            }
        }
    }
}
