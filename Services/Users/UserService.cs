using Domain.Users;
using Faith.Shared.Users;

namespace Services.Users
{
    public class UserService : IUserService
    {
        private static readonly List<UserDto.Index> users = new();

        static UserService()
        {
            var fakeUsers = new UserFaker().Generate(10).Select(x => new UserDto.Index
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName
            });
            users.AddRange(fakeUsers);
        }

        public async Task<IEnumerable<UserDto.Index>> GetIndexAsync()
        {
            await Task.Delay(100);
            return users.Select(u => new UserDto.Index
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName
            });
        }

        public async Task<UserDto.Index> GetDetailAsync(int userId)
        {
            await Task.Delay(100);
            return users.SingleOrDefault(u => u.Id == userId);
        }

        public async Task DeleteAsync(int userId)
        {
            await Task.Delay(100);
            var user = users.SingleOrDefault(u => u.Id == userId);
            users.Remove(user);
        }

        public async Task<int> CreateAsync(UserDto.Create model)
        {
            await Task.Delay(100);
            var user = new User(model.FirstName, model.LastName);

            var mappedUser = new UserDto.Index
            {
                Id = users.Max(u => u.Id) + 1,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            users.Add(mappedUser);
            return mappedUser.Id;
        }

        public Task UpdateAsync(UserDto.Update model)
        {
            throw new System.NotImplementedException();
        }

        Task<UserDto.Detail> IUserService.GetDetailAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
