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

        public async Task<PostDto.Detail> GetPostAsync(int id)
        {
            var response = await client.GetFromJsonAsync<PostDto.Detail>($"{endpoint}/{id}");
            return response;
        }




        public async Task<List<PostDto.Detail>> GetPostAsync()
        {
            //
            /*var response = await client.GetFromJsonAsync<List<PostDto.Detail>>(endpoint);
            Console.WriteLine(response);
            return response;*/
            throw new NotImplementedException();
        }

        




        public Task<int> AddPostAsync(PostDto.Create model)
        {
            throw new NotImplementedException();
        }

        public Task<PostDto.Detail> GetDetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task<bool> RemovePostAysync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePostAsync(PostDto.Create model)
        {
            throw new NotImplementedException();
        }
    }
}
