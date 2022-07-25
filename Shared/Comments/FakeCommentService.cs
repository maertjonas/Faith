using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Shared.Comments
{
    public class FakeCommentService : ICommentService
    {

        private static readonly List<CommentDto.Index> _comments = new();

        static FakeCommentService()
        {
            var commentIds = 0;


            var lorem = new Bogus.DataSets.Lorem(locale: "nl");
            Random rand = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            int rangeWords = rand.Next(3, 15);

            var commentFaker = new Faker<CommentDto.Index>("nl")
            .UseSeed(1337)
            .RuleFor(x => x.Id, _ => ++commentIds)
            //.RuleFor(x => x.DatePlaced, _ => start.AddDays(rand.Next(range)))
            .RuleFor(x => x.Text, f => lorem.Paragraph(rangeWords));
            

            _comments = commentFaker.Generate(5);
        }

        public Task<IEnumerable<CommentDto.Index>> GetIndexAsync()
        {
            return Task.FromResult(_comments.AsEnumerable());
        }

        public Task DeleteAsync(int commentId)
        {
            var u = _comments.SingleOrDefault(u => u.Id == commentId);
            _comments.Remove(u);
            return Task.CompletedTask;
        }

    }
}
