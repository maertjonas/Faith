using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Shared.Users
{
    public class FakeUserService : IUserService
    {
        private static readonly List<UserDto.Detail> _users = new();

        static FakeUserService()
        {
            Random rand = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;

            var userIds = 0;

            var userFaker = new Faker<UserDto.Detail>("nl")
            .UseSeed(1337)
            .RuleFor(x => x.Id, _ => ++userIds)
            .RuleFor(x => x.FirstName, f => f.Person.FirstName)
            .RuleFor(x => x.LastName, f => f.Person.LastName)
            .RuleFor(x => x.DateOfBirth, _ => start.AddDays(rand.Next(range)));

            _users = userFaker.Generate(10);
        }

        public Task<IEnumerable<UserDto.Index>> GetIndexAsync()
        {
            return Task.FromResult(_users.Select(u => new UserDto.Index
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName
            }));
        }

        public Task<UserDto.Detail> GetDetailAsync(int userId)
        {
            return Task.FromResult(_users.Single(u => u.Id == userId));
        }

        public Task DeleteAsync(int userId)
        {
            var u = _users.SingleOrDefault(u => u.Id == userId);
            _users.Remove(u);
            return Task.CompletedTask;
        }
    }
}