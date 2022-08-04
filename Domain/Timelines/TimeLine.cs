using Ardalis.GuardClauses;
using Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Timelines
{
    public class TimeLine
    {
        private IEnumerable<Post> posts;
        public IEnumerable<Post> Posts
        {
            get { return posts; }
            set
            {
                posts = Guard.Against.NullOrEmpty(value, nameof(posts));
            }
        }

    }
}
