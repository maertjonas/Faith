using Domain.Comments;
using Domain.Posts;
using Faith.Shared.Comments;
using Faith.Shared.Posts;
using Microsoft.EntityFrameworkCore;
using Service.Data;

namespace Service.Posts
{
    public class PostService : IPostService
    {

        public PostService(ApplicationContext context)
        {
            _context = context;
        }

        private readonly ApplicationContext _context;
        private readonly DbSet<Post> _posts;
        private readonly DbSet<Comment> _comments;

        private IQueryable<Post> GetPostById(int id) => _posts
            .AsNoTracking()
            .Where(p => p.Id == id);

        public async Task<PostDto.Detail> GetPostAsync(int id)
        {
            await Task.Delay(100);
            return _context.Posts.Include(p => p.Comments).Where(p => p.Id == id).AsNoTracking().Select(p => new PostDto.Detail
            {
                Id = p.Id,
                Text = p.Text,
                Date = p.Date,
                Pinned = p.Pinned,
                Archive = p.Archive,
                Comments = CommentsToCommentDtoConverter(p.Comments)
            }).AsSingleQuery().SingleOrDefault()!;
        }

        public async Task<List<PostDto.Detail>> GetPostAsync()
        {
            
            await Task.Delay(100);
            return _context.Posts.Include(p=> p.Comments).AsNoTracking().Select(p => new PostDto.Detail
            {
                Id= p.Id,
                Text = p.Text,
                Date = p.Date,
                Pinned = p.Pinned,
                Archive = p.Archive,
                Comments = CommentsToCommentDtoConverter(p.Comments)
            }).AsSingleQuery().ToList()!;
        }

        

        public Task<PostDto.Detail> GetDetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddPostAsync(PostDto.Create model)
        {
            var p = new Post(model.Date, model.Text, model.Archive, model.Pinned, model.Image) { };
            var post = _context.Posts.Add(p);
            await _context.SaveChangesAsync();
            return post.Entity.Id;
        }

        public async Task<bool> RemovePostAysync(int id)
        {
            var post = _context.Posts.Where(p => p.Id == id).SingleOrDefault();
            _context.Posts.Remove(post);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task UpdatePostAsync(int id, PostDto.Create model)
        {
           
            Post p = _context.Posts.Where(p => p.Id == id).SingleOrDefault()!;
            
            if (p != null)
            {
                p.Text = model.Text;
                p.Date = model.Date;
                p.Archive = model.Archive;
                p.Pinned = model.Pinned;
                p.Image = model.Image;
            }
            await _context.SaveChangesAsync();
            return;
        }

        private static List<CommentDto.Index> CommentsToCommentDtoConverter(List<Comment> commentsList)
        {
            List<CommentDto.Index> commentDtoList = new List<CommentDto.Index>();
            CommentDto.Index cDto;
            foreach(Comment c in commentsList) 
            {
                cDto = new CommentDto.Index
                {
                    Id = c.Id,
                    Text = c.Text,
                    Date = c.Date
                };
                commentDtoList.Add(cDto);
            }
            return commentDtoList;
        }

        /*private static List<Comment> CommentDtoToCommentsConverter(List<CommentDto.Index> commentDtoList)
        {
            List<Comment> commentList = new List<Comment>();
            Comment c;
            foreach(CommentDto.Index cDto in commentDtoList)
            {
                c = new Comment(cDto.Date, cDto.Text);
                commentList.Add(c);
            }
            return commentList;
        }*/
    }
}
