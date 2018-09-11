using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiApplication.Data;
using ApiApplication.Models;

namespace ApiApplication.Controllers
{
	[Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly GymContext context;

        public UsersController(GymContext context)
        {
            this.context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            var users = this.context.Users;
			return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser([FromRoute] int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var user = await this.context.Users.FindAsync(id);

            if (user == null)
            {
                return this.NotFound();
            }

            return this.Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User user)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != user.UserId)
            {
                return this.BadRequest();
            }

            this.context.Entry(user).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.UserExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.NoContent();
        }

		[HttpPost("update")]
		public async Task<IActionResult> EditUser([FromBody] User user)
		{
			this.context.Users.Update(user);
			await this.context.SaveChangesAsync();

			return this.Ok(user);
		}

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

			if (this.OAuthIdentityExists(user.OAuthId))
			{
				return this.Ok(this.context.Users.Where(u => u.OAuthId == user.OAuthId));
			}

	        user.InsertedDate = DateTime.UtcNow;
            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction($"GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var user = await this.context.Users.FindAsync(id);
            if (user == null)
            {
                return this.NotFound();
            }

            this.context.Users.Remove(user);
            await this.context.SaveChangesAsync();

            return this.Ok(user);
        }

        private bool UserExists(int id)
        {
            return this.context.Users.Any(e => e.UserId == id);
        }

	    private bool OAuthIdentityExists(string oAuthId)
	    {
		    return this.context.Users.Any(u => u.OAuthId == oAuthId);
	    }
    }
}