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
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {


        private readonly ResponseServices ResponsesServices;

        public ResponseController(ResponseServices ResponseService)
        {
            ResponsesServices = ResponseService;
        }

        // GET: api/Responses 
        [HttpGet]
        public async Task<IEnumerable<Response>> Get()
        {
            return await ResponsesServices.GetResponsesList();
        }

        // GET api/<ResponseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> Get(int id)
        {
            Response Response = await ResponsesServices.GetResponseById(id);
            if (Response == null)
            {
                return NotFound();
            }

            return Ok(Response);
        }

        // POST api/<ResponseController>
        [HttpPost]
        public async Task<ActionResult<Response>> Post(Response Response)
        {
            await ResponsesServices.CreateResponse(Response);

            return CreatedAtAction("Post", new { id = Response.ResponseId }, Response);
        }

        // PUT api/<ResponseController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Response Response)
        {
            if (id != Response.ResponseId)
            {
                return BadRequest("Not a valid Response id");
            }

            await ResponsesServices.UpdateResponse(Response);

            return NoContent();
        }

        // DELETE api/<ResponseController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Response id");

            Response Response = await ResponsesServices.GetResponseById(id);
            if (Response == null)
            {
                return NotFound();
            }

            await ResponsesServices.DeleteResponse(id);

            return NoContent();
        }
    }
}
