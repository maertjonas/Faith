using Domain.Users;
using Faith.Shared.Users;
using Microsoft.EntityFrameworkCore;
using Services.Data;

namespace Services.Users
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _context;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDto.Index>> GetIndexAsync()
        {
            await Task.Delay(100);
            return _context.Users.AsNoTracking().Select(u => new UserDto.Index
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName
            });
        }

        public async Task<UserDto.Index> GetDetailAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateAsync(UserDto.Create model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserDto.Update model)
        {
            throw new NotImplementedException();
        }

        Task<UserDto.Detail> IUserService.GetDetailAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
