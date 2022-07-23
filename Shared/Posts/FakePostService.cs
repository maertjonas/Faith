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
        private static readonly List<PostDto.Index> _products = new();
        static FakePostService()
        {
            var productIds = 0;
            var productFaker = new Faker<PostDto.Index>("nl")
            .UseSeed(1337) // Always return the same products
            .RuleFor(x => x.Id, _ => ++productIds)
            .RuleFor(x => x.Text, f => f.Commerce.ProductName());
            _products = productFaker.Generate(25);
        }

        public Task<IEnumerable<PostDto.Index>> GetIndexAsync()
        {
            return Task.FromResult(_products.AsEnumerable());
        }
    }
}
