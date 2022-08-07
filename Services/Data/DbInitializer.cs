using Domain.Comments;
using Domain.Posts;

namespace Services.Data
{
    public  class DbInitializer
    {
        private readonly ApplicationContext _context;


        public DbInitializer(ApplicationContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                Seeder();
            }
        }

        /*public void Seed(IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
            context.Database.EnsureCreated();
            Seeder(context);
        }*/

        public void Seeder()
        {
            var post = _context.Posts.FirstOrDefault();
            if (post != null) return;

            Console.WriteLine("Ik kom na de return");

            DateTime now = DateTime.Now;

            var comment1 = new Comment { Id = 1, Text = "Tekstje", Date = now };
            var comment2 = new Comment { Id = 2,  Text = "Tekstje2", Date = now };

            /*var posts = new Post[]
            {
                new Post
                {
                    Id = 10,
                    Text = "Post 1",
                    Date = now,
                    Comments = new List<Comment> { comment1, comment2 }
                }
                ,
                new Post
                {
                    Id = 11,
                    Text = "Post 1",
                    Date = now,
                    Comments = new List<Comment> { comment1, comment2 }
                }
            };*/
            _context.Posts.Add(new Post
                {
                    Id = 10,
                    Text = "Post 1",
                    Date = now,
                    Comments = new List<Comment> { comment1, comment2 }
                });

            //context.Posts.AddRange(posts);
            _context.SaveChanges();

        }

        /*public static void Initialize(ApplicationContext context)
        {

            
            if (context.Users.Any()
                && context.Posts.Any()
                && context.Comments.Any())
            {
                return;   // DB has been seeded
            }

            DateTime now = DateTime.Now;

            var comment1 = new Comment { Text = "Tekstje", Date = now };
            var comment2 = new Comment { Text = "Tekstje2", Date = now };

            var posts = new Post[]
            {
                new Post
                {
                    Text = "Post 1",
                    Date = now,
                    Comments = new List<Comment> { comment1, comment2 }
                }
            };

            context.Posts.AddRange(posts);
            context.SaveChanges();

        }*/
    }
}
