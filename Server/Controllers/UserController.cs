using Domain.Users;
using Faith.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Faith.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public UserController() { }

        /**
        * * GET
        * * /api/users
        * ? gets all users
        */
        [HttpGet]
        [SwaggerOperation(Summary = "gets all users", Description = "Returns all registered users")]
        [SwaggerResponse(200, "Ok")]
        public ActionResult<List<User>> GetAll() => UserService.GetAll();

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
        public ActionResult<User> Get(int id)
        {
            var user = UserService.Get(id);
            if (user is null)
                return NotFound();
            return user;
        }

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
        public IActionResult Create(User user)
        {
            UserService.Add(user);
            return CreatedAtAction(nameof(Create), new { id = user.Id }, user);
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
        public IActionResult Update(int id, User user)
        {
            if (id != user.Id)
                return BadRequest();

            User existingUser = UserService.Get(id);

            if (existingUser is null)
                return NotFound();

            UserService.Update(user);

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
        public IActionResult Delete(int id)
        {
            User user = UserService.Get(id);

            if (user is null)
                return NotFound();

            UserService.Delete(id);

            return NoContent();
        }
    }
}