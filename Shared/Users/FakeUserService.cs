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
        private static readonly List<UserDto.Index> _users = new();

        static FakeUserService()
        {
            var userIds = 0;

            var userFaker = new Faker<UserDto.Index>("nl")
            .UseSeed(1337)
            .RuleFor(x => x.Id, _ => ++userIds)
            .RuleFor(x => x.FirstName, f => f.Person.FirstName)
            .RuleFor(x => x.LastName, f => f.Person.LastName);

            _users = userFaker.Generate(8);
        }

        public Task<IEnumerable<UserDto.Index>> GetIndexAsync()
        {
            return Task.FromResult(_users.AsEnumerable());
        }
    }
}