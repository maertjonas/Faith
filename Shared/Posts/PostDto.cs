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
    }
}
