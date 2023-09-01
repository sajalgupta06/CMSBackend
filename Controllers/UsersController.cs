using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMSBackend.Models;
using BCrypt.Net;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using CMSBackend.Data;
using Microsoft.AspNetCore.Authorization;

namespace CMSBackend2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public UsersController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        // GET: Check Token

        [Route("/api/checkToken")]
        [HttpGet, Authorize]
        public async Task<IActionResult> CheckToken()
        {
          

            return  Ok(new { message = "true" });
        }



        // GET: api/Users
        [HttpGet,Authorize(Roles="ADMIN")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            return await _context.Users.Where(u=>u.Role=="USER").ToListAsync();
        }
        [Route("allUsers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            return await _context.Users.ToListAsync();
        }
        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // Update User Status

        [Route("updateStatus")]
        [HttpPut]
        public async Task<IActionResult> UpdateStatus([FromBody]int id)
        {

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound(new { message = "User Not Found" });
            }
            if(user.Status==0)
            {

            user.Status = 1;
            }
            else
            {
                user.Status = 0;


            }
            try
            {

            await _context.SaveChangesAsync();
            return Ok(new { message = "User Updated Successfully" });
            }
            catch
            {
                return BadRequest( new { message = "Error while changing status" });
            }


        }



        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'CmsdatabaseContext.Users'  is null.");
            }

            user.Status = 1;
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = passwordHash;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new {message="Account Created Successfully"});
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}"), Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }


      





        public class LoginModel
        {
            public string email { get; set; }
            public string password { get; set; }
        }

        [Route("login")]

        [HttpPost]


        public async Task<ActionResult<User>> Login(LoginModel loginmodel)
        {

            var user = await _context.Users.Where(u => u.Email == loginmodel.email).FirstOrDefaultAsync();

            if (user == null)
            {
                return BadRequest(new { message = "User Not Found" });
            }
            if (!BCrypt.Net.BCrypt.Verify(loginmodel.password, user.Password))
            {
                return BadRequest( new { message ="Invalid Credentials" });
            }

                
            if(user.Status==0)
            {
                return BadRequest(new { message = "User is Temporarily Blocked" });
            }

            string token = CreateToken(user);

            return Ok(new
            {
                message ="Login Successfully",
                token= token
            });
        }

        public class TokenModel
        {
            public string token { get; set; }

        }

    


        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
            new Claim("Email",user.Email),
            new Claim("Role",user.Role),
            new Claim("Name",user.Name),
            new Claim("Id",user.Id.ToString()),
            new Claim(ClaimTypes.Role,"ADMIN"),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
               _configuration.GetSection("AppSettings:Token").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
     
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;

        }
    }
}
