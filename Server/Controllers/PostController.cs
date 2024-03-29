﻿using Faith.Shared.Posts;
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

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a post by id", Description = "Returns a post by given parameter Id")]
        [SwaggerResponse(200, "Ok")]
        [SwaggerResponse(404, "Not found")]
        public Task<PostDto.Detail> GetPostByIdAsync(int id) => _postService.GetPostAsync(id)!;


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

        //[Authorize(Roles = "")]
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates post by id", Description = "Updates post")]
        [SwaggerResponse(201, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> UpdateAsync(int id, PostDto.Create model)
        {
            //Should be Update model
            //Todo
            var post = await _postService.GetPostAsync(id);

            if (post is null)
                return NotFound();

            await _postService.UpdatePostAsync(id, model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes post by id", Description = "Deletes post")]
        [SwaggerResponse(201, "No Content")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> RemovePostAysync(int id)
        {
            var post = await _postService.GetPostAsync(id);
            if (post is null)
                return NotFound();
            await _postService.RemovePostAysync(id);
            return NoContent();
        }

        
    }
}