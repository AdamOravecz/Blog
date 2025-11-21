using Microsoft.EntityFrameworkCore;

namespace BlogApi.Models
{
    public class BlogDbConntext : DbContext
    {
        public BlogDbConntext()
        {
        }
        public BlogDbConntext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Blogger> Bloggers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Database=Blog;user=root;password=");
        }
    }
}
