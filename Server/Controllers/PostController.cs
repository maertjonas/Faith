using Faith.Shared.Posts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Faith.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [AllowAnonymous]
        [HttpGet]
        [SwaggerOperation(Summary = "Get all posts", Description = "Returns all posts")]
        [SwaggerResponse(200, "Ok")]
        public Task<List<PostDto.Detail>> GetPostAsync() => _postService.GetPostAsync();


        //[Authorize(Roles = "")]
        [HttpPost]
        [SwaggerOperation(Summary = "Create a new post", Description = "Registers a new post to the database")]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        public async Task<ActionResult<int>> Create(PostDto.Create model)
        {
            var postId = await _postService.AddPostAsync(model);
            return CreatedAtAction(nameof(Create), new { id = postId }, model);
        }
    }
}