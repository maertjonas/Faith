using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Shared.Comments
{
    public static class CommentDto
    {
        public class Index
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public string DatePlaced { get; set; }
        }
    }
}
