using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Shared.Posts
{
    public static class PostRequest
    {
        public class GetIndex
        {
            public string Text { get; set; }
            public string Date { get; set; } //= DateTime.Now.ToString("yyyyMMddHHmmssffff");
            public bool Archive { get; set; }
            public bool Pinned { get; set; }
            public string Image { get; set; }
        }

        public class GetDetail
        {
            public int PostId { get; set; }
        }

        public class Delete
        {
            public int PostId { get; set; }
        }

        public class Create
        {
            public PostDto.Mutate Post { get; set; }
        }

        public class Edit
        {
            public int PostId { get; set; }
            public PostDto.Mutate Post { get; set; }
        }
    }
}
