using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Shared.Users
{
    public interface IUserService
    {
        //Task<IEnumerable<UserDto.Index>> GetAuth0Users();
        Task<List<UserDto.Index>> GetIndexAsync();
        Task<UserDto.Index> GetDetailAsync(int userId);
        //Task<UserDto.Index> GetDetailAsyncByAuth0Id(string auth0Id);
        Task<int> CreateAsync(UserDto.Create model);
        Task UpdateAsync(UserDto.Update model);

        //param string auth0Id
        Task<bool> DeleteAsync(int userId);
    }
}