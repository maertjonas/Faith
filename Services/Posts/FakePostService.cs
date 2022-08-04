using Faith.Shared.Posts;

namespace Services.Posts
{
    public class FakePostService : IPostService
    {
        private static readonly List<PostDto.Detail> _posts = new();

        static FakePostService()
        {
            DateTime today = DateTime.Now;
            _posts = new List<PostDto.Detail>()
            {
                new PostDto.Detail{
                    Id = 1, Text = "TestText", Archive = false, Pinned = true, Date = today.AddDays(-1) 
                },
                new PostDto.Detail{
                    Id = 2, Text = "TestText2", Archive = false, Pinned = false, Date = today.AddDays(-2) 
                },
                new PostDto.Detail{
                    Id = 3, Text = "TestText3", Archive = false, Pinned = false, Date = today.AddDays(-3) 
                },
                new PostDto.Detail{
                    Id = 4, Text = "TestText4", Archive = false, Pinned = false, Date = today.AddDays(-4) 
                },
            };

        }

        public async Task<IEnumerable<PostDto.Index>> GetIndexAsync()
        {
            await Task.Delay(100);
            return _posts;
        }

        public async Task<PostDto.Detail> GetDetailAsync(int postId)
        {
            await Task.Delay(100);
            return _posts.SingleOrDefault(p => p.Id == postId);
        }

        public Task DeleteAsync(int postId)
        {
            throw new NotImplementedException();
        }

    }
}
