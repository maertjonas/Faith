using Domain.Users;
using Faith.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Faith.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public UserController() { }

        [HttpGet]
        public ActionResult<List<User>> GetAll() => UserService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = UserService.Get(id);

            if (user is null)
                return NotFound();

            return user;
        }
    }
}
