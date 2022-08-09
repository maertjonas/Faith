using Domain.Users;
using Faith.Shared.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Faith.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [AllowAnonymous]
        [HttpGet]
        [SwaggerOperation(Summary = "Gets all users", Description = "Returns all registered users")]
        [SwaggerResponse(200, "Ok")]
        public Task<List<UserDto.Index>> GetIndexAsync() => _userService.GetIndexAsync();

    }
}