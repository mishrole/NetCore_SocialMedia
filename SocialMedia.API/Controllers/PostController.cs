using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Interfaces;
using System.Threading.Tasks;

namespace SocialMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        /* We need to receive the concrete implementations that we are going
         * to use for the abstractions references.
         * 
         * IPostRepository: Interface abstraction 
        */

        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            // var posts = new PostRepository().GetPosts();
            var posts = await _postRepository.GetPosts();
            return Ok(posts);
        }
    }
}
