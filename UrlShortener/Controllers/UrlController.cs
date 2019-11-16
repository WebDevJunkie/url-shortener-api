using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UrlShortener.Context;
using UrlShortener.Dto;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlController : ControllerBase
    {
        private UrlContext _context;

        public UrlController(UrlContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var urls = _context.Urls.ToList();
            return Ok(urls);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var url = _context.Urls.Find(id);

            if (url == null)
                return NotFound();

            return Ok(url);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UrlDto urlDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var url = new Url() { Description = urlDto.Description, Redirect = urlDto.Redirect };
            _context.Urls.Add(url);
            _context.SaveChanges();

            return Ok(url);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var url = _context.Urls.Find(id);

            if (url == null)
                return NotFound();

            _context.Urls.Remove(url);
            _context.SaveChanges();

            return Ok();
        }
    }
}
