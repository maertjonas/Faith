using Domain.Users;

namespace Faith.Server.Services
{
    public class UserService
    {
        static List<User> Users { get; }
        static int nextId = 4;
        static UserService()
        {
            Users = new List<User>
            {
                new User { Id = 1, FirstName = "John", LastName = "Doe" },
                new User { Id = 2, FirstName = "Mike", LastName = "Doe" },
                new User { Id = 3, FirstName = "Pike", LastName = "Doe" }
            };
        }

        public static List<User> GetAll() => Users;

        public static User Get(int id) => Users.FirstOrDefault(u => u.Id == id);

        public static User Add(User user)
        {
            user.Id = nextId++;
            Users.Add(user);
            return user;
        }

        public static void Delete(int id)
        {
            var user = Get(id);
            if (user is null)
                return;

            Users.Remove(user);
        }

        public static void Update(User user)
        {
            var index = Users.FindIndex(u => u.Id == user.Id);
            if (index == -1)
                return;

            Users[index] = user;
        }
    }
}
