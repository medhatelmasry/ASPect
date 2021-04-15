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
        A Controller with basic CRUD operations for the Assignments Model.
        Can be accessed at baseUrl/api/Assignment
    */
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AssignmentController(ApplicationDbContext context)
        {
            _context = context;
        }


        /// GET
        /// Summary: Returns all Assignments in the System with the CourseId, if no id
        ///             is specified will return ALL Assignments from the db
        /// Produces: 
        ///     application/json
        /// Parameters: 
        ///     in: QueryParam
        ///     description: The id of the Course
        ///     required: false
        ///     type: Int
        /// Responses: 
        ///     200 : Success
        ///     404 : NoContent if there are no results
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignmentsByCourseIdOrAll(
                            [FromQuery] int? id)
        {
            if (id == null) {
                return await _context.Assignments.ToListAsync();
            }

            var results = await _context.Assignments.Where(x => x.courseId == id).ToListAsync();
            if (results.Count > 0) {
                return Ok(results);
            } else {
                return NotFound();
            }
        }

        /// GET
        /// Summary: Returns an Assignment matching an id
        /// Produces: 
        ///     application/json
        /// Parameters: 
        ///    id
        ///     in: path
        ///     description: The Id of the Assignment
        ///     required: True
        ///     type: Integer
        /// Responses: 
        ///     200 : Success
        ///     404 : NotFound, If there is not Assignment.
        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> GetAssignment(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);

            if (assignment == null)
            {
                return NotFound();
            }

            return assignment;
        }



        /// PUT
        /// Summary: Edits an assignment matching an id
        /// Produces: 
        ///     application/json
        /// Parameters: 
        ///    id
        ///     in: path
        ///     description: The id of the assignment to edit
        ///     required: True
        ///     type: Integer
        ///    assignment
        ///     in: path
        ///     description: The edited assignment 
        ///     required: True
        ///     type: Assignment
        /// Responses: 
        ///     200 : Success
        ///     400 : BadRequest, If id does not match the Assignment Id 
        ///     404 : NotFound, If there is no Assignment.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignment(int id, Assignment assignment)
        {
            if (id != assignment.AssignmentId)
            {
                return BadRequest();
            }

            _context.Entry(assignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(id))
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
        /// Summary: Creates an assignment 
        /// Produces: 
        ///     application/json
        /// Parameters: 
        ///    assignment
        ///     in: body
        ///     description: The Assignment to create
        ///     required: True
        ///     type: Assignment
        /// Responses: 
        ///     200 : Success
        [HttpPost]
        public async Task<ActionResult<Assignment>> PostAssignment(Assignment assignment)
        {
            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignment", new { id = assignment.AssignmentId }, assignment);
        }

       
        /// PUT
        /// Summary: Deletes an assignment matching an id
        /// Produces: 
        ///     application/json
        /// Parameters: 
        ///    id
        ///     in: path
        ///     description: The id of the assignment to delete
        ///     required: True
        ///     type: Integer
        /// Responses: 
        ///     204 : NoContent, If the assignment is removed
        ///     404 : NotFound, If there is not assignment to delete.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Helper functions used to see if an assignment exists 
        //Parameters: The id of the assignment as an Integer
        private bool AssignmentExists(int id)
        {
            return _context.Assignments.Any(e => e.AssignmentId == id);
        }
    }
}
