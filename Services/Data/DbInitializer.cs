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
        public void Seeder()
        {
            String now = DateTime.Now.ToString("yyyyMMddHHmmssffff");

            var comment1 = new Comment { Text = "Tekstje", Date = now };
            var comment2 = new Comment { Text = "Tekstje2", Date = now };

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
    }
}
