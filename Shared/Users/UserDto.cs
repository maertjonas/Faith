using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Shared.Users
{
    public static class UserDto
    {
        public class Index
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class Detail : Index
        {
            public DateTime DateOfBirth { get; set; }
        }

        public class Create
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public class Validator : AbstractValidator<UserDto.Create>
            {
                public Validator()
                {
                    RuleFor(user => user.FirstName).NotNull().WithName("First name").WithMessage("Please ensure that you have entered your {PropertyName}");
                    RuleFor(user => user.LastName).NotNull().WithName("Last name").WithMessage("Please ensure that you have entered your {PropertyName}");
                }
            }
        }

        public class Update : Create { }
    }
}
