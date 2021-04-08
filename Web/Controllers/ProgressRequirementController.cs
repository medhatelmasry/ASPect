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
        A Controller with basic CRUD operations for the ProjectRequirements Model.
        Can be accessed at baseUrl/api/ProjectRequirement
    */
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectRequirementController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectRequirementController(ApplicationDbContext context)
        {
            _context = context;
        }


        /// GET
        /// Summary: Returns all ProjectRequirements in the System with the AssignmentId, if no id
        ///             is specified will return ALL ProjectRequirements from the db
        /// Produces: 
        ///     application/json
        /// Parameters: 
        ///     in: QueryParam
        ///     description: The id of the Assignment
        ///     required: false
        ///     type: Int
        /// Responses: 
        ///     200 : Success
        ///     404 : NoContent if there are no results
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectRequirement>>> GetProjectRequirmentByAssignmentId(
                            [FromQuery] int? id)
        {
            if (id == null) {
                return await _context.ProjectRequirements.ToListAsync();
            }

            var results = await _context.ProjectRequirements.Where(x => x.AssignmentId == id).ToListAsync();

            if (results.Count > 0) {
                return NotFound();
            } else {
                return Ok(results);
            }
        }

        /// GET
        /// Summary: Returns a projectRequirement matching an id
        /// Produces: 
        ///     application/json
        /// Parameters: 
        ///    id
        ///     in: path
        ///     description: The Id of the ProjectRequirement
        ///     required: True
        ///     type: Integer
        /// Responses: 
        ///     200 : Success
        ///     404 : NotFound, If there is not Requirement.
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectRequirement>> GetProjectRequirement(int id)
        {
            var requirement = await _context.ProjectRequirements.FindAsync(id);

            if (requirement == null)
            {
                return NotFound();
            }

            return requirement;
        }



        /// PUT
        /// Summary: Edits a projectRequirement matching an id
        /// Produces: 
        ///     application/json
        /// Parameters: 
        ///    id
        ///     in: path
        ///     description: The id of the ProjectRequirement to edit
        ///     required: True
        ///     type: Integer
        ///    requirement
        ///     in: path
        ///     description: The edited project requirement
        ///     required: True
        ///     type: ProjectRequirement
        /// Responses: 
        ///     200 : Success
        ///     400 : BadRequest, If id does not match the ProjectRequirement Id 
        ///     404 : NotFound, If there is not Requirement.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectRequirement(int id, ProjectRequirement requirement)
        {
            if (id != requirement.Id)
            {
                return BadRequest();
            }

            _context.Entry(requirement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectRequirementExists(id))
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
        /// Summary: Creates a projectRequirement 
        /// Produces: 
        ///     application/json
        /// Parameters: 
        ///    requirement
        ///     in: body
        ///     description: The project requirement to create
        ///     required: True
        ///     type: ProjectRequirement
        /// Responses: 
        ///     200 : Success
        [HttpPost]
        public async Task<ActionResult<ProjectRequirement>> PostProjectRequirement(ProjectRequirement requirement)
        {
            _context.ProjectRequirements.Add(requirement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectRequirement", new { id = requirement.Id }, requirement);
        }

       
        /// PUT
        /// Summary: Deletes a projectRequirement matching an id
        /// Produces: 
        ///     application/json
        /// Parameters: 
        ///    id
        ///     in: path
        ///     description: The id of the ProjectRequirement to delete
        ///     required: True
        ///     type: Integer
        /// Responses: 
        ///     204 : NoContent, If the requirement is removed
        ///     404 : NotFound, If there is not Requirement to delete.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectRequirement(int id)
        {
            var projectRequirement = await _context.ProjectRequirements.FindAsync(id);
            if (projectRequirement == null)
            {
                return NotFound();
            }

            _context.ProjectRequirements.Remove(projectRequirement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Helper functions used to see if a requirement exists 
        //Parameters: The id of the ProjectRequirement as an Integer
        private bool ProjectRequirementExists(int id)
        {
            return _context.ProjectRequirements.Any(e => e.Id == id);
        }
    }
}
