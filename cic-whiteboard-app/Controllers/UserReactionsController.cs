using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CIC.WhiteboardApp.Data.Data;
using CIC.WhiteboardApp.Data.Entities;

namespace CIC.WhiteboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReactionsController : ControllerBase
    {
        private readonly WhiteboardDbContext _context;

        public UserReactionsController(WhiteboardDbContext context)
        {
            _context = context;
        }

        // GET: api/UserReactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReaction>>> GetUserReactions()
        {
            return await _context.UserReactions.ToListAsync();
        }

        // GET: api/UserReactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReaction>> GetUserReaction(int id)
        {
            var userReaction = await _context.UserReactions.FindAsync(id);

            if (userReaction == null)
            {
                return NotFound();
            }

            return userReaction;
        }

        // PUT: api/UserReactions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserReaction(int id, UserReaction userReaction)
        {
            if (id != userReaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(userReaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserReactionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserReactions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserReaction>> PostUserReaction(UserReaction userReaction)
        {
            _context.UserReactions.Add(userReaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserReaction", new { id = userReaction.Id }, userReaction);
        }

        // DELETE: api/UserReactions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserReaction>> DeleteUserReaction(int id)
        {
            var userReaction = await _context.UserReactions.FindAsync(id);
            if (userReaction == null)
            {
                return NotFound();
            }

            _context.UserReactions.Remove(userReaction);
            await _context.SaveChangesAsync();

            return userReaction;
        }

        private bool UserReactionExists(int id)
        {
            return _context.UserReactions.Any(e => e.Id == id);
        }
    }
}
