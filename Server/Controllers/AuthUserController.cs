using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Auth0.ManagementApi;
using Faith.Shared.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Faith.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Administrator")]

    public class AuthUserController : ControllerBase
    {
        private readonly ManagementApiClient _managementApiClient;

        public AuthUserController(ManagementApiClient managementApiClient)
        {
            _managementApiClient = managementApiClient;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto.Index>> GetUsers()
        {
            var users = await _managementApiClient.Users.GetAllAsync(new GetUsersRequest(), new PaginationInfo());
            return users.Select(x => new UserDto.Index
            {
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName
            });
        }
    }
}
