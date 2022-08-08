using Domain.Posts;
using Domain.Comments;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Services.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<User> Users => Set<User>();
    }
}


