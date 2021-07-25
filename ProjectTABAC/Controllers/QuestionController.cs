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
    public class QuestionController : ControllerBase
    {


        private readonly QuestionServices QuestionsServices;

        public QuestionController(QuestionServices QuestionService)
        {
            QuestionsServices = QuestionService;
        }

        // GET: api/Questions 
        [HttpGet]
        public async Task<IEnumerable<Question>> Get()
        {
            return await QuestionsServices.GetQuestionsList();
        }

        // GET api/<QuestionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> Get(int id)
        {
            Question Question = await QuestionsServices.GetQuestionById(id);
            if (Question == null)
            {
                return NotFound();
            }

            return Ok(Question);
        }

        // POST api/<QuestionController>
        [HttpPost]
        public async Task<ActionResult<Question>> Post(Question Question)
        {
            await QuestionsServices.CreateQuestion(Question);

            return CreatedAtAction("Post", new { id = Question.QuestionId }, Question);
        }

        // PUT api/<QuestionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Question Question)
        {
            if (id != Question.QuestionId)
            {
                return BadRequest("Not a valid Question id");
            }

            await QuestionsServices.UpdateQuestion(Question);

            return NoContent();
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Question id");

            Question Question = await QuestionsServices.GetQuestionById(id);
            if (Question == null)
            {
                return NotFound();
            }

            await QuestionsServices.DeleteQuestion(id);

            return NoContent();
        }
    }
}
