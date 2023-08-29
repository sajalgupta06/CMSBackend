using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMSBackend.Data;
using CMSBackend.Models;

namespace CMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderedItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderedItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderedItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderedItem>>> GetOrderedItems()
        {
          if (_context.OrderedItems == null)
          {
              return NotFound();
          }
            return await _context.OrderedItems.ToListAsync();
        }

        // GET: api/OrderedItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderedItem>> GetOrderedItem(int id)
        {
          if (_context.OrderedItems == null)
          {
              return NotFound();
          }
            var orderedItem = await _context.OrderedItems.FindAsync(id);

            if (orderedItem == null)
            {
                return NotFound();
            }

            return orderedItem;
        }

        // PUT: api/OrderedItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderedItem(int id, OrderedItem orderedItem)
        {
            if (id != orderedItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderedItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderedItemExists(id))
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

        // POST: api/OrderedItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderedItem>> PostOrderedItem(OrderedItem orderedItem)
        {
          if (_context.OrderedItems == null)
          {
              return Problem("Entity set 'ApplicationDbContext.OrderedItems'  is null.");
          }
            _context.OrderedItems.Add(orderedItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderedItem", new { id = orderedItem.Id }, orderedItem);
        }

        // DELETE: api/OrderedItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderedItem(int id)
        {
            if (_context.OrderedItems == null)
            {
                return NotFound();
            }
            var orderedItem = await _context.OrderedItems.FindAsync(id);
            if (orderedItem == null)
            {
                return NotFound();
            }

            _context.OrderedItems.Remove(orderedItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderedItemExists(int id)
        {
            return (_context.OrderedItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
