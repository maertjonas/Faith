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


        [HttpGet]
        [SwaggerOperation(Summary = "Gets all users", Description = "Returns all registered users")]
        [SwaggerResponse(200, "Ok")]
        public Task<List<UserDto.Index>> GetIndexAsync() => _userService.GetIndexAsync();

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a user by id", Description = "Returns a user by given parameter Id")]
        [SwaggerResponse(200, "Ok")]
        [SwaggerResponse(404, "Not found")]
        public Task<UserDto.Index> Get(int id) => _userService.GetIndexAsync(id);

        [HttpPost]
        [SwaggerOperation(Summary = "Registers a user to the database", Description = "Registers a user to the database")]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        public async Task<ActionResult<int>> CreateAsync(UserDto.Create model)
        {
            var userId = await _userService.CreateAsync(model);
            return CreatedAtAction(nameof(CreateAsync), new { id = userId }, model);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates user by id", Description = "Updates user")]
        [SwaggerResponse(201, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> UpdateAsync(UserDto.Update model)
        {
            //GetDetailAsync
            var existingUser = await _userService.GetIndexAsync(model.Id);

            if (existingUser is null)
                return NotFound();

            await _userService.UpdateAsync(model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes user by id", Description = "Deletes user by id")]
        [SwaggerResponse(201, "No Content")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _userService.DeleteAsync(id);
            if (!isDeleted) return NotFound();
            return NoContent();
        }



    }
}