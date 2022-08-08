using Domain.Posts;
using Microsoft.EntityFrameworkCore;

namespace Services.Data
{
    public class PostContext : DbContext
    {
        public PostContext(DbContextOptions<PostContext> options)
            : base(options)
        {
        }
        public DbSet<Post> Posts => Set<Post>();
    }
}
