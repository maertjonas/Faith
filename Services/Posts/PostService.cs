using Domain.Posts;
using Faith.Shared.Posts;
using Microsoft.EntityFrameworkCore;
using Services.Data;

namespace Services.Posts
{
    public class PostService : IPostService
    {

        private readonly ApplicationContext _context;
           
        public PostService(ApplicationContext context)
        {
            _context = context;
        }

        //Get all
        //PostDto.Detail instead?
        //.Include(p => p.Comments)
        public async Task<IEnumerable<PostDto.Index>> GetIndexAsync()
        {
            await Task.Delay(100);
            return _context.posts.AsNoTracking().Select(p => new PostDto.Detail
            {
                Id = p.Id,
                Pinned = p.Pinned,
                Archive = p.Archive,
                Text = p.Text,
                Date = DateTime.Now
                //Image + comments?
            }) ;
        }

        //Get one detail
        public async Task<PostDto.Detail> GetDetailAsync(int id)
        {
            await Task.Delay(100);
            PostDto.Detail post = _context.posts.Where(p => p.Id == id).AsNoTracking().Select(p => new PostDto.Detail
            {
                Id = p.Id,
                Pinned= p.Pinned,
                Archive = p.Archive,
                Text = p.Text,
                Date = DateTime.Now
                //Image + comments?
            }).SingleOrDefault();
            return post;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Post post = _context.posts.Where(p => p.Id == id).SingleOrDefault();
            _context.posts.Remove(post);

            await _context.SaveChangesAsync();
            return true;
        }

        //UpdatePost






    }
}
