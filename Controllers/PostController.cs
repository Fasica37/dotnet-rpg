using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postServices)
        {
            _postService = postServices;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetPostDto>>> GetSingle(int id)
        {
            return Ok(await _postService.GetPostById(id));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetPostDto>>>> Get()
        {
            return Ok(await _postService.GetAllPosts());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetPostDto>>> AddPost(AddPostDto post)
        {
            return Ok(await _postService.AddPost(post));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetPostDto>>> UpdatePost(UpdatePostDto Post)
        {
            var response = await _postService.UpdatePost(Post);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetPostDto>>> DeletePost(int id)
        {
            var response = await _postService.DeletePost(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}