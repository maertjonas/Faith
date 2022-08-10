using Ardalis.GuardClauses;
using Domain.Common;
using Faith.Shared.RoleTypes;
using System.Text.Json.Serialization;
using Faith.Shared.Genders;

namespace Domain.Users
{
    public class User : Entity
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = Guard.Against.NullOrWhiteSpace(value, nameof(firstName)); }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = Guard.Against.NullOrWhiteSpace(value, nameof(lastName)); }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = Guard.Against.NullOrWhiteSpace(value, nameof(email)); }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = Guard.Against.NullOrWhiteSpace(value, nameof(password)); }
        }
        private String dateOfBirth;
        public String DateOfBirth { get; set; }

        private RoleType roleType;
        public RoleType RoleType
        {
            get { return roleType; }
            set { roleType = Guard.Against.EnumOutOfRange(value, nameof(roleType)); }
        }

        private Gender gender;
        public Gender Gender
        {
            get { return gender; }
            set { gender = Guard.Against.EnumOutOfRange(value, nameof(gender)); }
        }

        [JsonIgnore]
        private List<User> juniors;
        public List<User> Juniors
        {
            get { return juniors; }
            set
            {
                juniors = (List<User>)Guard.Against.NullOrEmpty(value, nameof(juniors));
            }
        }

        public User()
        {

        }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        } 
        public User(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public User(string firstName, string lastName, string email, string password, string dateOfBirth, RoleType roleType, Gender gender) : this(firstName, lastName)
        {
            Email = email;
            Password = password;
            DateOfBirth = dateOfBirth;
            RoleType = roleType;
            Gender = gender;
        }
    }
}
