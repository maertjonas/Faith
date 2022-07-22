using Ardalis.GuardClauses;
using Domain.Common;
using Faith.Shared.RoleTypes;
using Faith.Shared.Gender;

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
        private DateTime dateOfBirth;
        public DateTime DateOfBirth { get; set; }

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
    }
}
