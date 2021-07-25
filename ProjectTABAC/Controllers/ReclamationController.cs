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
    public class ReclamationController : ControllerBase
    {

        private readonly ReclamationServices ReclamationsServices;

        public ReclamationController(ReclamationServices ReclamationService)
        {
            ReclamationsServices = ReclamationService;
        }

        // GET: api/<ReclamationController> 
        [HttpGet]
        public async Task<IEnumerable<Reclamation>> Get()
        {
            return await ReclamationsServices.GetReclamationsList();
        }

        // GET api/<ReclamationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reclamation>> Get(int id)
        {
            Reclamation Reclamation = await ReclamationsServices.GetReclamationById(id);
            if (Reclamation == null)
            {
                return NotFound();
            }

            return Ok(Reclamation);
        }

        // POST api/<ReclamationController>
        [HttpPost]
        public async Task<ActionResult<Reclamation>> Post(Reclamation Reclamation)
        {
            await ReclamationsServices.CreateReclamation(Reclamation);

            return CreatedAtAction("Post", new { id = Reclamation.ReclamationId }, Reclamation);
        }

        // PUT api/<ReclamationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Reclamation Reclamation)
        {
            if (id != Reclamation.ReclamationId)
            {
                return BadRequest("Not a valid Reclamation id");
            }

            await ReclamationsServices.UpdateReclamation(Reclamation);

            return NoContent();
        }

        // DELETE api/<ReclamationController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid reclamation id");

            Reclamation Reclamation = await ReclamationsServices.GetReclamationById(id);
            if (Reclamation == null)
            {
                return NotFound();
            }

            await ReclamationsServices.DeleteReclamation(id);

            return NoContent();
        }
    }
}
