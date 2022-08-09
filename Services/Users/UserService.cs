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

        private IQueryable<User> GetUserById(int id) =>
            _context.Users.AsNoTracking().Where(u => u.Id == id);

        public async Task<List<UserDto.Index>> GetIndexAsync()
        {
            List<UserDto.Index> users = await (_context.Users.AsNoTracking().Select(u => new UserDto.Index
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Password = u.Password,
                RoleType = u.RoleType,
                Juniors = UsersToUserDtoConverter(u.Juniors)
            })).OrderBy(u => u.LastName).ThenBy(u => u.FirstName).ToListAsync();
            return users;
        }


        public Task<UserDto.Index> GetDetailAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateAsync(UserDto.Create model)
        {
            var u = new User(model.FirstName, model.LastName, model.Email, model.Password, model.DateOfBirth, model.RoleType) { };
            var user = _context.Users.Add(u);
            await _context.SaveChangesAsync();
            return user.Entity.Id;
        }

        public async Task<bool> DeleteAsync(int userId)
        {
            var user = _context.Users.Where(p => p.Id == userId).SingleOrDefault();
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
            return true;
        }

        public Task UpdateAsync(UserDto.Update model)
        {
            throw new NotImplementedException();
        }

        private static List<UserDto.Index> UsersToUserDtoConverter(List<User> usersList)
        {
            List<UserDto.Index> userDtoList = new List<UserDto.Index>();
            UserDto.Index uDto;
            foreach(User u in usersList)
            {
                uDto = new UserDto.Index
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Password = u.Password,
                    RoleType = u.RoleType
                };
                userDtoList.Add(uDto);
            }
            return userDtoList;
        }
    }
}
