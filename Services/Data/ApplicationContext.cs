using Domain.Comments;
using Domain.Posts;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Services.Data
{
    public partial class ApplicationContext : DbContext
    {

        //????


        /*public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){ }
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }*/

        protected readonly IConfiguration Configuration;

        public ApplicationContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("FaithDb"));
        }

        public DbSet<Post> posts => Set<Post>();
        public DbSet<Comment> comments => Set<Comment>();
        public DbSet<User> users => Set<User>();
    }
}


