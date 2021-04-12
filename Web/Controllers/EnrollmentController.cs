using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPectLibrary;
using Web.Data;

namespace Web.Controllers
{
    /**
        A Controller with basic CRUD operations for the Enrollment Model.
        Can be accessed at baseUrl/api/Enrollment
    */
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentController(ApplicationDbContext context)
        {
            _context = context;
        }


        /// GET
        /// Summary: Returns all Enrollments in the System
        /// Produces: 
        ///     application/json
        /// Responses: 
        ///     200 : Success
        ///     404 : NoContent if there are no results
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollments(
                            [FromQuery] int? id)
        {
            var results = await _context.Enrollments
                         .Include(e => e.Offering)
                         .Include(e => e.Student)
                         .Select(o => new {
                             EnrollmentId = o.EnrollmentId,
                             Offering = o.Offering,
                             StudentId = o.Student.Id,
                             StudentFirstName = o.Student.FirstName,
                             StudentLastName = o.Student.LastName
                         })
                         .ToListAsync();

            if (results.Count > 0) {
                return Ok(results);
            } else {
                return NotFound();
            }
        }

        /// GET
        /// Summary: Returns all Enrollments matching an id
        /// Produces: 
        ///     application/json
        /// Parameters: 
        ///    id
        ///     in: path
        ///     description: The Id of the Enrollment
        ///     required: True
        ///     type: Integer
        /// Responses: 
        ///     200 : Success
        ///     404 : NotFound, If there is no enrollments.
        [HttpGet("{id}")]
        public async Task<ActionResult<Enrollment>> GetEnrollment(int id)
        {
            var enrollment = await _context.Enrollments
                                            .Include(e => e.Offering)
                                            .FirstOrDefaultAsync(i => i.EnrollmentId == id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return enrollment;
        }



        /// PUT
        /// Summary: Edits an Enrollment matching an id
        /// Produces: 
        ///     application/json
        /// Parameters: 
        ///    id
        ///     in: path
        ///     description: The id of the enrollment to edit
        ///     required: True
        ///     type: Integer
        ///    enrollment
        ///     in: path
        ///     description: The edited enrollment 
        ///     required: True
        ///     type: Enrollment
        /// Responses: 
        ///     200 : Success
        ///     400 : BadRequest, If id does not match the enrollment Id 
        ///     404 : NotFound, If there is no enrollment.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnrollment(int id, Enrollment enrollment)
        {
            if (id != enrollment.EnrollmentId)
            {
                return BadRequest();
            }

            _context.Entry(enrollment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(id))
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

        /// POST
        /// Summary: Creates an enrollment 
        /// Produces: 
        ///     application/json
        /// Parameters: 
        ///    enrollment
        ///     in: body
        ///     description: The Enrollment to create
        ///     required: True
        ///     type: Enrollment
        /// Responses: 
        ///     200 : Success
        [HttpPost]
        public async Task<ActionResult<Enrollment>> PostEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnrollment", new { id = enrollment.EnrollmentId }, enrollment);
        }

       
        /// PUT
        /// Summary: Deletes an Enrollment matching an id
        /// Produces: 
        ///     application/json
        /// Parameters: 
        ///    id
        ///     in: path
        ///     description: The id of the enrollment to delete
        ///     required: True
        ///     type: Integer
        /// Responses: 
        ///     204 : NoContent, If the enrollment is removed
        ///     404 : NotFound, If there is not enrollment to delete.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Helper functions used to see if an enrollment exists 
        //Parameters: The id of the enrollment as an Integer
        private bool EnrollmentExists(int id)
        {
            return _context.Enrollments.Any(e => e.EnrollmentId == id);
        }
    }
}
