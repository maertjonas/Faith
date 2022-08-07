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
            Console.WriteLine("Ensure deleted called");
            if (_context.Database.EnsureCreated())
            {
                Console.WriteLine("Ensure created called");
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
            Console.WriteLine("Seeder called");

            String now = DateTime.Now.ToString("yyyyMMddHHmmssffff");

            var comment1 = new Comment { Text = "Tekstje", Date = now };
            var comment2 = new Comment { Text = "Tekstje2", Date = now };

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
                    Text = "Post 1",
                    Date = now,
                    Image = "",
                    Comments = new List<Comment> { comment1, comment2 }
                });

            //context.Posts.AddRange(posts);
            _context.SaveChanges();
        }

        public static void Initialize(ApplicationContext context)
        {
            Console.WriteLine("Init called");

            /*
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
            context.SaveChanges();*/

        }
    }
}
