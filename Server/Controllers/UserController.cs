using Domain.Users;
using Faith.Server.Services;
using Faith.Shared.Users;
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

        /**
        * * GET
        * * /api/users
        * ? gets all users
        */
        [HttpGet]
        [SwaggerOperation(Summary = "gets all users", Description = "Returns all registered users")]
        [SwaggerResponse(200, "Ok")]
        public Task<IEnumerable<UserDto.Index>> GetIndexAsync() => _userService.GetIndexAsync();

        /**
        * * GET
        * * /api/users/{id}
        * ? gets a user by id
        * @param id
        */
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "get a user by id", Description = "Returns a user by given parameter Id")]
        [SwaggerResponse(200, "Ok")]
        [SwaggerResponse(404, "User not found")]
        public Task<UserDto.Detail> Get(int id) => _userService.GetDetailAsync(id);
        //Detail or Index?

        /**
        * * POST
        * * /api/users
        * ? creates a new user
        * @param user
        */
        [HttpPost]
        [SwaggerOperation(Summary = "registers a user to the database", Description = "Registers a user to the database")]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        public async Task<ActionResult<int>> CreateAsync(UserDto.Create model)
        {
            var id = await _userService.CreateAsync(model);
            return CreatedAtAction("GetDetail", id);
        }

        /**
        * * PUT
        * * /api/users/{id}
        * ? updates a user by id
        * @param id
        */
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update user with given id", Description = "Updates user")]
        [SwaggerResponse(201, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> UpdateAsync(int id, UserDto.Update model)
        {
            var existingUser = await _userService.GetDetailAsync(id);

            if (existingUser is null)
                return NotFound();

            await _userService.UpdateAsync(model);

            return NoContent();
        }

        /**
        * * DELETE
        * * /api/users/{id}
        * ? deletes a user by id
        * @param id
        */
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "deletes user with given id", Description = "Deletes user")]
        [SwaggerResponse(201, "No Content")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetDetailAsync(id);

            if (user is null)
                return NotFound();

            await _userService.DeleteAsync(id);

            return NoContent();
        }
    }
}