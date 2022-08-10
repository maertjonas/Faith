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
        //Task<UserDto.Index> GetDetailAsyncByAuth0Id(string auth0Id);


        Task<List<UserDto.Index>> GetIndexAsync();
        //Task<UserDto.Index> GetIndexAsync(int userId);
        Task<UserDto.Detail> GetDetailAsync(int userId);
        Task<int> CreateAsync(UserDto.Create model);
        Task UpdateAsync(UserDto.Update model);

        //param string auth0Id
        Task<bool> DeleteAsync(int userId);
    }
}