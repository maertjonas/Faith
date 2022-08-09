using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Shared.Users
{
    public interface IUserService
    {
        Task<List<UserDto.Index>> GetIndexAsync();
        Task<UserDto.Index> GetIndexAsync(int userId);
        //Task<UserDto.Index> GetDetailAsyncByAuth0Id(string auth0Id);
        Task<int> CreateAsync(UserDto.Create model);
        Task UpdateAsync(UserDto.Update model);
        Task<bool> DeleteAsync(int userId);
    }
}