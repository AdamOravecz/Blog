using BlogApi.Models;
using BlogApi.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
