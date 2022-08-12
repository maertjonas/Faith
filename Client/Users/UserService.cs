using Faith.Shared.Posts;
using Faith.Shared.Users;
using System.Net.Http.Json;

namespace Faith.Client.Users
{
    public class UserService : IUserService
    {
        private readonly HttpClient client;
        private const string endpoint = "/Api/user";

        public UserService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<UserDto.Index>> GetIndexAsync()
        {
            var response = await client.GetFromJsonAsync<List<UserDto.Index>>(endpoint);
            return response;
        }




        public Task<UserDto.Detail> GetDetailAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(UserDto.Create model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserDto.Update model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}