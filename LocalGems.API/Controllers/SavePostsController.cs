using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocalGems.API.Models;

namespace LocalGems.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavePostsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SavePostsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SavePosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SavePost>>> GetSavePost()
        {
            return await _context.SavePost.ToListAsync();
        }

        // GET: api/SavePosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SavePost>> GetSavePost(int id)
        {
            var savePost = await _context.SavePost.FindAsync(id);

            if (savePost == null)
            {
                return NotFound();
            }

            return savePost;
        }

        // PUT: api/SavePosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSavePost(int id, SavePost savePost)
        {
            if (id != savePost.Id)
            {
                return BadRequest();
            }

            _context.Entry(savePost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SavePostExists(id))
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

        // POST: api/SavePosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SavePost>> PostSavePost(SavePost savePost)
        {
            _context.SavePost.Add(savePost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSavePost", new { id = savePost.Id }, savePost);
        }

        // DELETE: api/SavePosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSavePost(int id)
        {
            var savePost = await _context.SavePost.FindAsync(id);
            if (savePost == null)
            {
                return NotFound();
            }

            _context.SavePost.Remove(savePost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SavePostExists(int id)
        {
            return _context.SavePost.Any(e => e.Id == id);
        }
    }
}
