using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Shared.Comments
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto.Index>> GetIndexAsync();
        Task DeleteAsync(int commentId);
    }
}
