using Microsoft.AspNetCore.Mvc;

namespace Momentum.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "Blog1";
        }

        [HttpGet("user/{userId}")]
        public IEnumerable<string> GetUserBlogsById(string userId)
        {
            return new string[] { "Blog1", "Blog2" };
        }

        [HttpPost]
        public string Create([FromBody] string value)
        {
            return $"{value} created";
        }
    }
}
