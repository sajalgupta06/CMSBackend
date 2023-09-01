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
         
            //  return await _context.Products.Include(p=>(p.Category as Category).Id).ToListAsync();
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

        [Route("productByCategory")]
        [HttpGet]
        public async Task<IActionResult> GetProductByCategory(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
             var product =  await _context.Products.Where(product => product.CategoryId == id).ToListAsync();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
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
            oldProduct.Image = product.Image;
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
        [HttpPost]

        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }

        
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Product Added Successfully" });
        }


        /*public async Task<ActionResult<ProductDto>> PostProduct(ProductDto product)
        {
          if (_context.Products == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
          }

            Product newProduct = new Product();
                newProduct.Id =product.Id;
                newProduct.Name = product.Name;
                newProduct.Description = product.Description;
                newProduct.CategoryId = product.CategoryId;
                newProduct.Price = product.Price;
                newProduct.Status = product.Status;

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            return Ok(new { message="Product Added Successfully"});
        }
*/



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
