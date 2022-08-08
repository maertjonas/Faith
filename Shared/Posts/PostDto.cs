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
            public string Date { get; set; }
            public bool Archive { get; set; }
            public bool Pinned { get; set; }
            public string Image { get; set; }
        }

        public class Mutate
        {
            public string Text { get; set; } = null;
            public string Date { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            public bool Archive { get; set; }
            public bool Pinned { get; set; }
            public string Image { get; set; }

            public class Validator : AbstractValidator<Mutate>
            {
                public Validator()
                {
                    RuleFor(x => x.Text).NotNull().NotEmpty().Length(1, 300).WithName("Text");
                    RuleFor(x => x.Date).NotNull().NotEmpty().WithName("Date");
                    RuleFor(x => x.Archive).NotNull().NotEmpty().WithName("Archive");
                    RuleFor(x => x.Pinned).NotNull().NotEmpty().WithName("Pinned");
                    RuleFor(x => x.Image).NotNull().NotEmpty().WithName("Image");
                }
            }

        }
    }
}
