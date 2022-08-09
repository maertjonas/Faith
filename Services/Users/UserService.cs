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

        public Task<int> CreateAsync(UserDto.Create model)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDto.Index>> GetIndexAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto.Index> GetIndexAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserDto.Update model)
        {
            throw new NotImplementedException();
        }
    }
}
