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
    [Route("api/Commantaire")]
    [ApiController]
    public class CommantaireController : ControllerBase
    {

        private readonly CommantaireServices CommantairesServices;

        public CommantaireController(CommantaireServices CommantaireService)
        {
            CommantairesServices = CommantaireService;
        }

        // GET: api/<CommantaireController> 
        [HttpGet]
        public async Task<IEnumerable<Commantaire>> Get()
        {
            return await CommantairesServices.GetCommantairesList();
        }

        // GET api/<CommantaireController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commantaire>> Get(int id)
        {
            Commantaire Commantaire = await CommantairesServices.GetCommantaireById(id);
            if (Commantaire == null)
            {
                return NotFound();
            }

            return Ok(Commantaire);
        }

        // POST api/<CommantaireController>
        [HttpPost]
        public async Task<ActionResult<Commantaire>> Post(Commantaire Commantaire)
        {
            await CommantairesServices.CreateCommantaire(Commantaire);

            return CreatedAtAction("Post", new { id = Commantaire.CommantaireId }, Commantaire);
        }

        // PUT api/<CommantaireController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Commantaire Commantaire)
        {
            if (id != Commantaire.CommantaireId)
            {
                return BadRequest("Not a valid Commantaire id");
            }

            await CommantairesServices.UpdateCommantaire(Commantaire);

            return NoContent();
        }

        // DELETE api/<CommantaireController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Commantaire id");

            Commantaire Commantaire = await CommantairesServices.GetCommantaireById(id);
            if (Commantaire == null)
            {
                return NotFound();
            }

            await CommantairesServices.DeleteCommantaire(id);

            return NoContent();
        }
    }
}

