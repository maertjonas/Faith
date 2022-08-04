using Bogus;
using Domain.Users;

namespace Services.Users
{
    public class UserFaker : Faker<User>
    {
        public UserFaker()
        {
            CustomInstantiator(f => new User(f.Name.FirstName(), f.Name.LastName()));
            RuleFor(u => u.Id, f => f.Random.Int());
        }
    }
}
