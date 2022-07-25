using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Shared.Posts
{
    public class FakePostService : IPostService
    {
        private static readonly List<PostDto.Detail> _posts = new();
        static FakePostService()
        {
            Random rand = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            var lorem = new Bogus.DataSets.Lorem(locale: "nl");
            int rangeLorem = rand.Next(2, 6);

            var postIds = 0;
            var postFaker = new Faker<PostDto.Detail>("nl")
            .UseSeed(1337) // Always return the same posts
            .RuleFor(x => x.Id, _ => ++postIds)
            .RuleFor(x => x.Text, _ => lorem.Paragraph(rangeLorem))
            .RuleFor(x => x.Archive, _ => rand.NextDouble() >= 0.5)
            .RuleFor(x => x.Pinned, _ => rand.NextDouble() >= 0.5)
            .RuleFor(x => x.Date, _ => start.AddDays(rand.Next(range)));
            _posts = postFaker.Generate(25);
        }

        public Task<IEnumerable<PostDto.Index>> GetIndexAsync()
        {
            return Task.FromResult(_posts.Select(x => new PostDto.Index
            {
                Id = x.Id,
                Text = x.Text
            }));
        }

        public Task<PostDto.Detail> GetDetailAsync(int postId)
        {
            return Task.FromResult(_posts.Single(x => x.Id == postId));
        }

        public Task DeleteAsync(int postId)
        {
            var postToDelete = _posts.SingleOrDefault(x => x.Id == postId);
            _posts.Remove(postToDelete);
            return Task.CompletedTask;
        }

    }
}
