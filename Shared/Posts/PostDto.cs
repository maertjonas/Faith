using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Shared.Posts
{
    public static class PostDto
    {
        public class Index
        {
            public int Id { get; set; }
            public string Text { get; set; }
        }
        public class Detail: Index
        {
            public DateTime Date { get; set; }
            public bool Archive { get; set; }
            public bool Pinned { get; set; }
        }

        public class Create
        {
            public string Text { get; set; } = null;
            public DateTime Date { get; set; } = DateTime.Now;

            public class Validator : AbstractValidator<Create>
            {
                public Validator()
                {
                    RuleFor(x => x.Text).NotEmpty().Length(1, 300).WithName("Text");
                    RuleFor(x => x.Date).NotNull().NotEmpty().WithName("Date");
                }
            }
        }
    }
}
