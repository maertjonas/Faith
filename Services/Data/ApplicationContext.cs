using Domain.Posts;
using Microsoft.EntityFrameworkCore;

namespace Services.Data
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){ }
            
        public DbSet<Post> posts => Set<Post>();
    }
}


