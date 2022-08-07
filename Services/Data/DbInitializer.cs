using Domain.Posts;

namespace Services.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            if(context.posts.Any() && context.comments.Any() && context.users.Any()){ return; } //DB has been seeded

            Random rand = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int rangeDate = (DateTime.Today - start).Days;
            var lorem = new Bogus.DataSets.Lorem(locale: "nl");
            int rangeLorem = rand.Next(2, 6);

            //Users


            //Posts
            int postCount = 0;

            var postList = new List<Post> { };

            while (postCount > 10)
            {
                postList.Add(new Post
                {
                    Text = lorem.Paragraph(rangeLorem),
                    Date = start.AddDays(rand.Next(rangeDate))
                });
                postCount++;
            }

            //Comments


            context.posts.AddRange(postList);
            context.SaveChangesAsync();
        }
    }
}
