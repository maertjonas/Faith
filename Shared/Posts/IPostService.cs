using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Shared.Posts
{
    public interface IPostService
    {
        Task<List<PostDto.Detail>> GetPostAsync();
        Task<PostDto.Detail> GetPostAsync(int id);
        Task<PostDto.Detail> GetDetailAsync(int id);
        Task<int> AddPostAsync(PostDto.Create model);
        Task<bool> RemovePostAysync(int id);
        Task UpdatePostAsync(int id, PostDto.Create model);


        /*Task<int> AddPostAsync(PostDto.Create model);
        Task<IEnumerable<PostDto.Index>> GetIndexAsync();
        Task<PostDto.Detail> GetDetailAsync(int postId);
        Task<bool> DeleteAsync(int postId);*/

        /*Task<PostResponse.GetIndex> GetIndexAsync(PostRequest.GetIndex request);
        Task<PostResponse.GetDetail> GetDetailAsync(PostRequest.GetDetail request);
        Task DeleteAsync(PostRequest.Delete request);
        Task<PostResponse.Create> CreateAsync(PostRequest.Create request);
        Task<PostResponse.Edit> EditAsync(PostRequest.Edit request);*/
    }
}
