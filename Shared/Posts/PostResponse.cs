using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Shared.Posts
{
    public static class PostResponse
    {
        public class GetIndex
        {
            public List<PostDto.Index> Posts { get; set; } = new();
        }

        public class GetDetail
        {
            public PostDto.Detail Post { get; set; }
        }

        public class Delete { }

        public class Create
        {
            public int PostId { get; set; }
        }

        public class Edit
        {
            public int PostId { get; set; }
        }
    }
}
