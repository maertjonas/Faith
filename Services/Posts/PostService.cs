using Domain.Posts;
using Faith.Shared.Posts;
using Microsoft.EntityFrameworkCore;
using Services.Data;

namespace Services.Posts
{
    public class PostService : IPostService
    {

        public PostService(ApplicationContext context)
        {
            _context = context;
        }

        private readonly ApplicationContext _context;
        private readonly DbSet<Post> _posts;

        private IQueryable<Post> GetPostById(int id) => _posts
            .AsNoTracking()
            .Where(p => p.Id == id);

        public async Task<IEnumerable<PostDto.Detail>> GetPostAsync()
        {
            await Task.Delay(100);
            return _context.Posts.AsNoTracking().Select(p => new PostDto.Detail
            {
                Id= p.Id,
                Text = p.Text,
                Date = p.Date
            });
        }

        public Task<PostDto.Detail> GetDetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddPostAsync(PostDto.Create model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemovePostAysync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePostAsync(int id, PostDto.Create model)
        {
            throw new NotImplementedException();
        }
    }
}
