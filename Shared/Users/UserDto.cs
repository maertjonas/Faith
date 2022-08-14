using Faith.Shared.Genders;
using Faith.Shared.RoleTypes;
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
            public string DateOfBirth { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            public Gender Gender { get; set; }
            public string Email { get; set; }
        }

        public class Detail : Index
        {
            
            public string Password { get; set; }
            public RoleType RoleType { get; set; }
            public List<UserDto.Index> Juniors { get; set; }
        }

        public class Create
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string DateOfBirth { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            public RoleType RoleType { get; set; }
            public Gender Gender { get; set; }
            //?public List<UserDto.Index> Juniors { get; set; }


            public class Validator : AbstractValidator<UserDto.Create>
            {
                public Validator()
                {
                    RuleFor(user => user.FirstName).NotNull().WithName("First name").WithMessage("Please ensure that you have entered your {PropertyName}");
                    RuleFor(user => user.LastName).NotNull().WithName("Last name").WithMessage("Please ensure that you have entered your {PropertyName}");
                    //Todo rules
                }
            }
        }

        public class Update : Create 
        {
            public int Id { get; set; }
        }
    }
}
