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
using Microsoft.AspNetCore.SignalR;
using CIC.WhiteboardApp.Hubs;
using Newtonsoft.Json;
using AutoMapper;
using CIC.WhiteboardApp.Dtos;

namespace CIC.WhiteboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        private readonly WhiteboardDbContext _context;
        private readonly IHubContext<PostHub> _hubContext;
        private readonly IMapper _mapper;

        public PostsController(WhiteboardDbContext context, IHubContext<PostHub> hubContext, IMapper mapper)
        {
            _context = context;
            _hubContext = hubContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {

            var posts = await _context.Posts
                .Include(p => p.Comments)
                .Include(p => p.Reactions)
                .ToListAsync();

            return Ok(posts);
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


        public async Task<ActionResult<Post>> PutPost(int id, Post post)
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

            await BroadcastPostUpdated(post.Id);

            return Ok();
        }


        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            _context.Posts.Add(post);

            await _context.SaveChangesAsync();

            await BroadcastPostUpdated(post.Id);

            return Ok();

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);

            await _context.SaveChangesAsync();

            await BroadcastPostUpdated(post.Id);

            return NoContent();
        }


        [HttpPost("{postId}/reactions")]
        public async Task<ActionResult<UserReaction>> PostReaction(int postId, UserReaction reactionDto)
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

            await BroadcastPostUpdated(postId);

            return Ok();
        }


        [HttpPost("{postId}/comments")]
        public async Task<ActionResult<UserComment>> PostComment(int postId, UserComment commentDto)
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

            await BroadcastPostUpdated(postId);

            return Ok();
        }


        [HttpDelete("{postId}/comments/{commentId}")]
        public async Task<IActionResult> DeleteComment(int postId, int commentId)
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

            await BroadcastPostUpdated(postId);

            return NoContent();
        }


        private async Task BroadcastPostUpdated(int postId)
        {
            Post post = await _context.Posts
                .Include(p => p.Comments)
                .Include(p => p.Reactions)
                .SingleOrDefaultAsync(p => p.Id == postId);

            PostDto dto = post == null ? null : _mapper.Map<PostDto>(post);

            await _hubContext.Clients.All.SendAsync("PostUpdated", postId, dto);

        }

        private async Task<bool> PostExists(int id)
        {
            return await _context.Posts.AnyAsync(e => e.Id == id);
        }

    }
}
