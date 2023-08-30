using CMSBackend.Data;
using CMSBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("details"), Authorize(Roles = "ADMIN")]
        [HttpGet]
        public async Task<IActionResult> GetDetails()
        {
            var categories = await _context.Categories.ToListAsync();
            var products = await _context.Products.ToListAsync();
            var orders = await _context.Orders.ToListAsync();

            return Ok(new
            {
                category = categories.Count,
                product = products.Count,
                order = orders.Count,
            });


        }

    }
}
