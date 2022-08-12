using Faith.Shared.Posts;
using System.Net.Http.Json;

namespace Faith.Client.Posts
{
    public class PostService : IPostService
    {
        private readonly HttpClient client;
        private const string endpoint = "/Api/post";

        public PostService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<PostDto.Detail>> GetPostAsync()
        {
            var response = await client.GetFromJsonAsync<List<PostDto.Detail>>(endpoint);
            return response;
        }

        


        public async Task<int> AddPostAsync(PostDto.Create model)
        {
            var posting = new PostDto.Create()
            {
                Text = model.Text, 
                Date = DateTime.Now.ToString("yyyyMMddHHmmssffff"), 
                Archive = false, 
                Pinned = false, 
                Image = ""
            };
            var response = await client.PostAsJsonAsync(endpoint, posting);
            var post = await response.Content.ReadFromJsonAsync<PostDto.Index>();

            return post.Id;
        }

        public Task<PostDto.Detail> GetDetailAsync(int id)
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

        public Task<PostDto.Detail> GetPostAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
