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
using Microsoft.AspNetCore.Cors;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CORSPolicy")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
        {
            JsonSerializerSettings options = new()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var studentsJson = JsonConvert.SerializeObject(await _context.Users.Include(u => u.Enrollments).ThenInclude(m => m.Offering).ThenInclude(m => m.Course).ToListAsync(), options);
            List<ApplicationUser> studentsDeserialized = System.Text.Json.JsonSerializer.Deserialize<List<ApplicationUser>>(studentsJson);

            return studentsDeserialized;
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetApplicationUser(string id)
        {
            var applicationUser = await _context.Users.Include(u => u.Enrollments).ThenInclude(m => m.Offering).ThenInclude(m => m.Course).FirstOrDefaultAsync(u => u.Id == id);

            JsonSerializerSettings options = new()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };


            if (applicationUser == null)
            {
                return NotFound();
            }

            var studentJson = JsonConvert.SerializeObject(applicationUser, options);
            ApplicationUser studentDeserialized = System.Text.Json.JsonSerializer.Deserialize<ApplicationUser>(studentJson);
            
            return studentDeserialized;
        }

        // PUT: api/Student/5
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
                var studentToUpdate = _context.Users.FirstOrDefault(u => u.Id == applicationUser.Id);
                if (studentToUpdate != null)
                {
                _context.Entry(studentToUpdate).CurrentValues.SetValues(applicationUser);
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

        // POST: api/Student
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // PasswordHash needs to be created from the client side and delivered through this call.
        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> PostApplicationUser(ApplicationUser applicationUser)
        {
            // change user id with new guid
            applicationUser.Id = Guid.NewGuid().ToString();

            // create new ApplicationRole
            string studentRoleId = Guid.NewGuid().ToString();
            var studentRole = new ApplicationRole()
            {
                Name = Constants.ASPectRoles.Student.RoleName,
                Description = Constants.ASPectRoles.Student.RoleDesc,
                Id = studentRoleId,
                ConcurrencyStamp = studentRoleId,
                CreatedDate = DateTime.Now
            };

            // create new IdentityUserRole
            var studentUserRole = new IdentityUserRole<string>()
            {
                RoleId = studentRoleId,
                UserId = applicationUser.Id
            };

            // Add to database
            _context.Users.Add(applicationUser);
            _context.Roles.Add(studentRole);
            _context.UserRoles.Add(studentUserRole);

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
