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
    public class ProductOffersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductOffersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductOffers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductOffer>>> GetProductOffer()
        {
            return await _context.ProductOffer.ToListAsync();
        }

        // GET: api/ProductOffers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductOffer>> GetProductOffer(int id)
        {
            var productOffer = await _context.ProductOffer.FindAsync(id);

            if (productOffer == null)
            {
                return NotFound();
            }

            return productOffer;
        }

        // PUT: api/ProductOffers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductOffer(int id, ProductOffer productOffer)
        {
            if (id != productOffer.Id)
            {
                return BadRequest();
            }

            _context.Entry(productOffer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductOfferExists(id))
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

        // POST: api/ProductOffers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductOffer>> PostProductOffer(ProductOffer productOffer)
        {
            _context.ProductOffer.Add(productOffer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductOffer", new { id = productOffer.Id }, productOffer);
        }

        // DELETE: api/ProductOffers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductOffer(int id)
        {
            var productOffer = await _context.ProductOffer.FindAsync(id);
            if (productOffer == null)
            {
                return NotFound();
            }

            _context.ProductOffer.Remove(productOffer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductOfferExists(int id)
        {
            return _context.ProductOffer.Any(e => e.Id == id);
        }
    }
}
