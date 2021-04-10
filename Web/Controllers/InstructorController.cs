using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPectLibrary;
using Web.Data;
using Web.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InstructorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Instructor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
        {
            JsonSerializerSettings options = new()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var instructorsJson = JsonConvert.SerializeObject(await _context.Users.Include(u => u.Enrollments).ToListAsync(), options);
            List<ApplicationUser> instructorsDeserialized = System.Text.Json.JsonSerializer.Deserialize<List<ApplicationUser>>(instructorsJson);

            return instructorsDeserialized;
        }

        // GET: api/Instructor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetApplicationUser(string id)
        {
            var applicationUser = await _context.Users.Include(u => u.Enrollments).FirstOrDefaultAsync(u => u.Id == id);

            JsonSerializerSettings options = new()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };


            if (applicationUser == null)
            {
                return NotFound();
            }

            var instructorJson = JsonConvert.SerializeObject(applicationUser, options);
            ApplicationUser instructorDeserialized = System.Text.Json.JsonSerializer.Deserialize<ApplicationUser>(instructorJson);
            
            return instructorDeserialized;
        }

        // PUT: api/Instructor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationUser(string id, ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return BadRequest();
            }

            try
            {
                var instructorToUpdate = _context.Users.FirstOrDefault(u => u.Id == applicationUser.Id);
                if (instructorToUpdate != null)
                {
                    _context.Entry(instructorToUpdate).CurrentValues.SetValues(applicationUser);
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUserExists(id))
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

        // POST: api/Instructor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // PasswordHash needs to be created from the client side and delivered through this call.
        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> PostApplicationUser(ApplicationUser applicationUser)
        {
            // change user id with new guid
            applicationUser.Id = Guid.NewGuid().ToString();

            // create new ApplicationRole
            string instructorRoleId = Guid.NewGuid().ToString();
            var instructorRole = new ApplicationRole()
            {
                Name = Constants.ASPectRoles.Instructor.RoleName,
                Description = Constants.ASPectRoles.Instructor.RoleDesc,
                Id = instructorRoleId,
                ConcurrencyStamp = instructorRoleId,
                CreatedDate = DateTime.Now
            };

            // create new IdentityUserRole
            var instructorUserRole = new IdentityUserRole<string>()
            {
                RoleId = instructorRoleId,
                UserId = applicationUser.Id
            };

            // Add to database
            _context.Users.Add(applicationUser);
            _context.Roles.Add(instructorRole);
            _context.UserRoles.Add(instructorUserRole);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ApplicationUserExists(applicationUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetApplicationUser", new { id = applicationUser.Id }, applicationUser);
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
