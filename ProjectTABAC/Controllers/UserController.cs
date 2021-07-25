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
    public class UserController : ControllerBase
    {

        private readonly UsersServices usersServices;

        public UserController(UsersServices userService)
        {
            usersServices = userService;
        }

        // GET: api/Users 
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsersList()
        {
            return await usersServices.GetUsersList();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult <User>> GetUserById(int id)
        {
            User user = await usersServices.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        // GET api/<UserController>/5
        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<User>> ConnectUser(string email, string password)
        {
            User user = await usersServices.ConnectUser(email,password);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);  
        }

        // POST api/<UserController>
        [HttpPost] 
        public async Task<IEnumerable<User>> Post(User user)
        {
            await usersServices.CreateUser(user);
            return await usersServices.GetUsersList();
            // return CreatedAtAction("Post", new { id = user.UserId }, user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")] 
        public async Task<IActionResult> Put(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest("Not a valid player id");
            }

            await usersServices.UpdateUser(user);

            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid user id");

            User user = await usersServices.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            await usersServices.DeleteUser(user);

            return NoContent();
        } 
    }
}
