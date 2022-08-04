﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Shared.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto.Index>> GetIndexAsync();
        Task<UserDto.Detail> GetDetailAsync(int userId);
        Task<int> CreateAsync(UserDto.Create model);
        Task UpdateAsync(UserDto.Update model);
        Task DeleteAsync(int userId);
    }
}