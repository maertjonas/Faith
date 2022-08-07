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
            return _context.Posts.AsNoTracking().Select(p => new PostDto.Detail
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
            PostDto.Detail post = _context.Posts.Where(p => p.Id == id).AsNoTracking().Select(p => new PostDto.Detail
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

        public async Task<int> AddPostAsync(PostDto.Create model)
        {
            var post = _context.Posts.Add(new Post(model.Text, model.Date));

            await _context.SaveChangesAsync();
            return post.Entity.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Post post = _context.Posts.Where(p => p.Id == id).SingleOrDefault();
            if(post is not null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
            
            return true;
        }

        //UpdatePost






    }
}
