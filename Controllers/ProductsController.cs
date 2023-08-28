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
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
          if (_context.Products == null)
          {
              return NotFound();
          }
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
          if (_context.Products == null)
          {
              return NotFound();
          }
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutProduct( Product product)
        {

            int id = product.Id;

            var oldProduct = await _context.Products.FindAsync(product.Id);

            if (oldProduct==null)
            {
                return BadRequest("Product Not Found");
            }

            oldProduct.Name = product.Name;
            oldProduct.Price = product.Price;
            oldProduct.Description  = product.Description; 
            oldProduct.CategoryId = product.CategoryId;
            await _context.SaveChangesAsync();

            return Ok(new {message="Product Updated Successfully"});
        }

        [Route("updateStatus")]
        [HttpPut]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {

            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound(new { message = "Product Not Found" });
            }
            if (product.Status == 0)
            {

                product.Status = 1;
            }
            else
            {
                product.Status = 0;


            }
            try
            {

                await _context.SaveChangesAsync();
                return Ok(new { message = "Product Status Changed" });
            }
            catch
            {
                return BadRequest(new { message = "Error while changing status" });
            }


        }



        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
          if (_context.Products == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
          }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(new { message="Product Added Successfully"});
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            try
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Product Deleted Successfully" });

            }
            catch
            {
                return BadRequest(new { message = "Error While Deleting Product" });

            }


        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
