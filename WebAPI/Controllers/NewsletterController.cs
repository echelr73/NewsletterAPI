using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsletterController : ControllerBase
    {
        private readonly ILogger<NewsletterController> _logger;
        private INewsletterCollection db = new NewsletterCollection();

        public NewsletterController(ILogger<NewsletterController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await db.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        { 
            return Ok(await db.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Newsletter newsletter)
        {
            if (newsletter == null)
                return BadRequest();

            if (newsletter.Title == string.Empty)
            {
                ModelState.AddModelError("Title", "The title shouldn't be empty");
            }

            await db.Insert(newsletter);

            return Created("Created", true);
               
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Newsletter newsletter)
        {
            if (newsletter == null)
                return BadRequest();

            if (newsletter.Title == string.Empty)
            {
                ModelState.AddModelError("Title", "The title shouldn't be empty");
            }

            await db.Update(newsletter);

            return Ok(true);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await db.Delete(id);

            return Ok(true);
        }
    }
}
