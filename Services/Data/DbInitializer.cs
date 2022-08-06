using Domain.Comments;
using Domain.Posts;

namespace Services.Data
{
    public static class DbInitializer
    {
        /*private readonly ApplicationContext _context;

        public DbInitializer(ApplicationContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                Fill();
            }
        }
*/


        /*public void Fill()*/
        public static void Initialize(ApplicationContext _context)
        {
            //DB has been seeded
            if (_context.posts.Any() && _context.comments.Any() && _context.users.Any()){ return; } 

            Random rand = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int rangeDate = (DateTime.Today - start).Days;
            var lorem = new Bogus.DataSets.Lorem(locale: "nl");
            int rangeLorem = rand.Next(2, 6);

            //Users


            //Posts
            /*int postCount = 0;

            var postList = new List<Post> { };

            while (postCount > 10)
            {
                postList.Add(new Post
                {
                    Text = lorem.Paragraph(rangeLorem),
                    Date = start.AddDays(rand.Next(rangeDate))
                });
                postCount++;
            }*/
            var comment = new Comment
            {
                Date = DateTime.Today,
                Text = "xxxxxx"
            };


            var postList = new Post[]
            {
                new Post
                {
                    Text = "Test",
                    Date = DateTime.Today,
                    Pinned = true,
                    Archive = true,
                    Image = "huh",
                    Comments = new List<Comment> { comment }

                },
                new Post
                {
                    Text = "Test2",
                    Date = DateTime.Today,
                    Pinned = true,
                    Archive = true,
                    Image = "huh",
                    Comments = new List<Comment> { comment }
                }
            };

            

            //Comments

            _context.posts.AddRange(postList);
            _context.SaveChangesAsync();
        }
    }
}
