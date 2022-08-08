using Faith.Shared.Posts;
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
    }
}