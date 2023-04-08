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
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Title should not be empty");
            }
            try
            {
                return Ok(await db.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest("No element was found with this ID");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Newsletter newsletter)
        {
            if (newsletter == null)
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(newsletter.Title))
            {
                return BadRequest("Title should not be empty");
            }

            if (string.IsNullOrEmpty(newsletter.HtmlBody))
            {
                return BadRequest("HtmlBody should not be empty");
            }

            try
            {
                await db.Insert(newsletter);

                return Created("Created", true);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "The element could not be created." });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Newsletter newsletter)
        {
            if (newsletter == null)
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(newsletter.Title))
            {
                return BadRequest("Title should not be empty");
            }

            if (string.IsNullOrEmpty(newsletter.HtmlBody))
            {
                return BadRequest("HtmlBody should not be empty");
            }

            try
            {
                await db.Update(newsletter);

                return Ok(true);
            }
            catch (Exception ex)
            {

                return BadRequest("The item could not be updated.");
            }
            

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await db.Delete(id);

                return Ok(true);

            }
            catch (Exception ex)
            {
                return BadRequest("The element could not be eliminated.");
            }
            
        }
    }
}
