using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Shared.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto.Index>> GetIndexAsync();
    }
}