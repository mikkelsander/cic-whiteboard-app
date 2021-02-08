using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CIC.WhiteboardApp.Data.Data;
using CIC.WhiteboardApp.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace CIC.WhiteboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        private readonly WhiteboardDbContext _context;

        public PostsController(WhiteboardDbContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Posts
                .Include(p => p.Comments)
                .Include(p => p.Reactions)
                .ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }


        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PostExists(id))
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


        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return Created("", post);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return post;
        }


        [HttpPost("{postId}/reactions")]
        public async Task<ActionResult<Post>> PostReaction(int postId, UserReaction reactionDto)
        {

            if (!await PostExists(postId))
            {
                return NotFound();
            }

            var reaction = _context.UserReactions
                .Find(reactionDto.PostId, reactionDto.UserId);

            if (reaction == null)
            {
                reaction = reactionDto;
                _context.UserReactions.Add(reaction);
            }
            else
            {
                //override reaction type (consider a non-reaction type to delete reactions)
                reaction.Type = reactionDto.Type;
                _context.UserReactions.Update(reaction);
            }

            await _context.SaveChangesAsync();

            return Created("", reaction);
        }


        [HttpPost("{postId}/comments")]
        public async Task<ActionResult<Post>> PostComment(int postId, UserComment commentDto)
        {

            if (!await PostExists(postId))
            {
                return NotFound();
            }

            var comment = _context.UserComments
                .Find(commentDto.Id);

            if (comment == null)
            {
                //map to new comment entity etc.
                comment = commentDto;
                _context.UserComments.Add(comment);
            }
            else
            {
                //override only editable values etc.
                comment = commentDto;
                _context.UserComments.Update(comment);
            }

            await _context.SaveChangesAsync();

            return Created("", comment);
        }


        [HttpDelete("{postId}/comments/{commentId}")]
        public async Task<ActionResult<Post>> DeleteComment(int postId, int commentId)
        {

            if (!await PostExists(postId))
            {
                return NotFound("Post not found.");
            }

            var comment = _context.UserComments
                .Find(commentId);

            if (comment == null)
            {
                return NotFound("Comment not found.");
            }

            _context.UserComments.Remove(comment);

            await _context.SaveChangesAsync();

            return Created("", comment);
        }


        private async Task<bool> PostExists(int id)
        {
            return await _context.Posts.AnyAsync(e => e.Id == id);
        }

    }
}
