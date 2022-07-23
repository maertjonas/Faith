﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Shared.Posts
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto.Index>> GetIndexAsync();
        Task<PostDto.Detail> GetDetailAsync(int postId);
        Task DeleteAsync(int postId);
    }
}
