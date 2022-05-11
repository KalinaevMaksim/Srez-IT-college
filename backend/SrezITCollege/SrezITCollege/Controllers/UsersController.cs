using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SrezITCollege.Models.DB;

namespace SrezITCollege.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SrezITCollegeContext _context;

        public UsersController(SrezITCollegeContext context)
        {
            _context = context;
        }

        // GET: api/Users/Authorization/dsf@gmail.com/123"
        [HttpPost("Authorization/{email}/{password}")]
        public async Task<ActionResult<int>> Authorization(string email, string password)
        {
            User user = await _context.Users.FirstOrDefaultAsync(us => us.Email == email && us.Password == password);
            return Ok(user == null ? -1 : user.Id);
        }

        // GET: api/Users/Registration/fiq sdfs sdg/dsf@gmail.com/123"
        [HttpPost("Registration/{fio}/{email}/{password}")]
        public async Task<IActionResult> Registration(string fio, string email, string password)
        {
            string[] names = fio.Split(' ');

            User user = new User()
            {
                Email = email,
                Password = password,
                LastName = names[0],
                FirstName = names[1],
                Patronomyc = names[2],
            };

            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        // GET: api/Users/RestorePassword/dsf@gmail.com
        [HttpPost("RestorePassword/{email}")]
        public async Task<IActionResult> RestorePassword(string email)
        {
            User user = await _context.Users.FirstOrDefaultAsync(us => us.Email == email);
            return Ok(user == null ? -1 : user.Id);
        }

        // GET: api/Users/ChangePassword/dsf@gmail.com/123"
        [HttpPost("ChangePassword/{email}/{password}")]
        public async Task<IActionResult> ChangePassword(string email, string password)
        {
            User user = await _context.Users.FirstOrDefaultAsync(us => us.Email == email);

            user.Password = password;

            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        // GET: api/Users/InfoUser/1
        [HttpGet("InfoUser/{id}")]
        public async Task<ActionResult> GetInfoUser(int id)
        {
            User user = await _context.Users.FindAsync(id);
            return Ok(user == null ? -1 : new { user.Photo, user.LastName, user.FirstName, user.Patronomyc });
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
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
            return _context.Users.Any(e => e.Id == id);
        }
    }
}