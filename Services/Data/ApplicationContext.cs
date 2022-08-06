using Domain.Comments;
using Domain.Posts;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Services.Data
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){ }

        public DbSet<Post> posts => Set<Post>();
        public DbSet<Comment> comments => Set<Comment>();
        public DbSet<User> users => Set<User>();
    }
}


