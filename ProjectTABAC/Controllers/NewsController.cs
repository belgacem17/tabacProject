using Microsoft.AspNetCore.Mvc;
using ProjectTABAC.Models;
using ProjectTABAC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTABAC.Controllers
{
    [Route("api/News")] 
    [ApiController]
    public class NewsController : ControllerBase
    {


        private readonly NewsServices NewsServices;

        public NewsController(NewsServices NewsService)
        {
            NewsServices = NewsService;
        }

        // GET: api/Newss 
        [HttpGet]
        public async Task<IEnumerable<News>> Get()
        {
            return await NewsServices.GetNewsList();
        }

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> Get(int id)
        {
            News News = await NewsServices.GetNewsById(id);
            if (News == null)
            {
                return NotFound();
            }

            return Ok(News);
        }

        // POST api/<NewsController>
        [HttpPost]
        public async Task<ActionResult<News>> Post(News News)
        {
            await NewsServices.CreateNews(News);

            return CreatedAtAction("Post", new { id = News.NewsId }, News);
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, News News)
        {
            if (id != News.NewsId)
            {
                return BadRequest("Not a valid News id");
            }

            await NewsServices.UpdateNews(News);

            return NoContent();
        }

        // DELETE api/<NewsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid News id");

            News News = await NewsServices.GetNewsById(id);
            if (News == null)
            {
                return NotFound();
            }

            await NewsServices.DeleteNews(id);

            return NoContent();
        }
    }
}
