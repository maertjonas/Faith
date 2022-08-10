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
                LastName = u.LastName
                /*Email = u.Email,
                Password = u.Password,
                RoleType = u.RoleType,
                Juniors = UsersToUserDtoConverter(u.Juniors)*/
            })).ToListAsync();
            return users;
        }

        /*public async Task<UserDto.Index> GetIndexAsync(int id)
        {
            await Task.Delay(100);
            return _context.Users.Include(u => u.Juniors).Where(u => u.Id == id).AsNoTracking().Select(u => new UserDto.Index
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName
                *//*Email = u.Email,
                Password = u.Password,
                RoleType = u.RoleType,
                Juniors = UsersToUserDtoConverter(u.Juniors)*//*
            }).AsSingleQuery().SingleOrDefault()!;
        }*/


        public async Task<UserDto.Detail> GetDetailAsync(int userId)
        {
            await Task.Delay(100);
            return _context.Users.Include(u => u.Juniors).Where(u => u.Id == userId).AsNoTracking().Select(u => new UserDto.Detail
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Password = u.Password,
                RoleType = u.RoleType,
                Juniors = UsersToUserDtoConverter(u.Juniors)
            }).AsSingleQuery().SingleOrDefault()!;
        }

        public async Task<int> CreateAsync(UserDto.Create model)
        {
            var u = new User(model.FirstName, model.LastName, model.Email, model.Password, model.DateOfBirth, model.RoleType, model.Gender) { };
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

        public async Task UpdateAsync(UserDto.Update model)
        {
            User u = _context.Users.Where(u => u.Id == model.Id).SingleOrDefault()!;
            if(u != null)
            {
                u.FirstName = model.FirstName;  
                u.LastName = model.LastName;
                u.Email = model.Email;
                u.Password = model.Password;
                u.DateOfBirth = model.DateOfBirth;
                u.RoleType = model.RoleType;
                u.Gender = model.Gender;
            }
            await _context.SaveChangesAsync();
        }

        private static List<UserDto.Index> UsersToUserDtoConverter(List<User> usersList)
        {
            List<UserDto.Index> userDtoList = new List<UserDto.Index>();
            UserDto.Index uDto;
            foreach(User u in usersList)
            {
                uDto = new UserDto.Detail
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
