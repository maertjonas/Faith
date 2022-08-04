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

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "gets all users", Description = "Returns all registered users")]
        [SwaggerResponse(200, "Ok")]
        public Task<IEnumerable<UserDto.Index>> GetIndexAsync() => _userService.GetIndexAsync();

        /// <summary>
        /// Gets a user by given id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "get a user by id", Description = "Returns a user by given parameter Id")]
        [SwaggerResponse(200, "Ok")]
        [SwaggerResponse(404, "User not found")]
        public Task<UserDto.Detail> Get(int id) => _userService.GetDetailAsync(id);
        //Detail or Index?

        /// <summary>
        /// Registers a user to the database
        /// </summary>
        /// <param name="model">Create user DTO</param>
        /// <returns>Created response</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "registers a user to the database", Description = "Registers a user to the database")]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        public async Task<ActionResult<int>> CreateAsync(UserDto.Create model)
        {
            var id = await _userService.CreateAsync(model);
            return CreatedAtAction("GetIndexAsync", id);
        }

        /// <summary>
        /// Updates a user by id
        /// </summary>
        /// <param name="id">User id to update</param>
        /// <param name="model">Data to update the user with</param>
        /// <returns>No Content</returns>
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

        /// <summary>
        /// Deletes a user by id
        /// </summary>
        /// <param name="id">User id to delete</param>
        /// <returns>No Content</returns>
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