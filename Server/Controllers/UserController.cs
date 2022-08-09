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

        /*[HttpPost]
        [SwaggerOperation(Summary = "Registers a user to the database", Description = "Registers a user to the database")]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        public async Task<ActionResult<int>> CreateAsync(UserDto.Create model)
        {
            var userId = await _userService.CreateAsync(model);
            return CreatedAtAction(nameof(CreateAsync), new { id = userId }, model);
        }*/



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