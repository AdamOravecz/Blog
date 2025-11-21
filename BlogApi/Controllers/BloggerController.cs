using BlogApi.Models;
using BlogApi.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloggerController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddNewBlogger(AddBloggerDto addBloggerDto)
        {
            try
            {
                using (var context = new BlogDbConntext())
                {
                    var blogger = new Blogger
                    {
                        Name = addBloggerDto.Name,
                        Password = addBloggerDto.Password,
                        Email = addBloggerDto.Email
                    };
                    if (blogger != null)
                    {
                        context.Bloggers.Add(blogger);
                        context.SaveChanges();
                        return StatusCode(201, new { Message = "Blogger created successfully", BloggerId = blogger.Id });
                    }

                    return NotFound(new { Message = "Blogger creation failed" });
                }
            }
            catch (Exception ex)
            {

                return NotFound(new { Message = ex.Message });
            }
         
        }
        [HttpGet]
        public ActionResult GetBloggers()
        {
            try
            {
                using (var context = new BlogDbConntext())
                {
                    var bloggers = context.Bloggers.ToList();
                    return Ok(bloggers);
                }
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
        [HttpGet("witPosts")]
        public ActionResult GetBloggersWithPost()
        {
            try
            {
                using (var context = new BlogDbConntext())
                {
                    var bloggersWithPost = context.Bloggers.Include(x=> x.Posts).ToList();
                    return Ok(bloggersWithPost);
                }
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public ActionResult GetBloggerById(int id)
        {
            try
            {
                using (var context = new BlogDbConntext())
                {
                    var blogger = context.Bloggers
                                         .Include(b => b.Posts)
                                         .FirstOrDefault(b => b.Id == id);
                    var blogger2 = new { Name = blogger.Name, Category = blogger.Posts.Select(x => x.Category) };
                    return NotFound(new { Message = "Blogger not found" });
                }
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
        [HttpGet("{id}/posts/count")]
        public ActionResult BloggerPostCount(int id)
        {
            
        }
    
}
}
