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
        A Controller with basic CRUD operations for the ProjectCategories Model.
        Can be accessed at baseUrl/api/ProjectCategories
    */
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCategories : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectCategories(ApplicationDbContext context)
        {
            _context = context;
        }


        /// GET
        /// Summary: Returns all ProjectCategories in the System
        /// Produces: 
        ///     application/json
        /// Responses: 
        ///     200 : Success
        ///     204 : NoContent if there are no results
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectCategory>>> GetProjectCategories()
        {
            var results = await _context.ProjectCategory.ToListAsync();

            if (results.Count > 0) {
                return Ok(results);
            } else {
                return NoContent();
            }
        }

        /// GET
        /// Summary: Returns a ProjectCategories matching an id
        /// Produces: 
        ///     application/json
        /// Parameters: 
        ///    id
        ///     in: path
        ///     description: The Id of the ProjectCategory
        ///     required: True
        ///     type: Integer
        /// Responses: 
        ///     200 : Success
        ///     404 : NotFound, If there is not Category.
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectCategory>> GetProjectCategory(int id)
        {
            var category = await _context.ProjectCategory.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }



        /// PUT
        /// Summary: Edits a ProjectCategory matching an id
        /// Produces: 
        ///     application/json
        /// Parameters: 
        ///    id
        ///     in: path
        ///     description: The id of the ProjectCategory to edit
        ///     required: True
        ///     type: Integer
        ///    category
        ///     in: path
        ///     description: The edited project category
        ///     required: True
        ///     type: ProjectCategory
        /// Responses: 
        ///     200 : Success
        ///     400 : BadRequest, If id does not match the ProjectCategory Id 
        ///     404 : NotFound, If there is not Category.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectCategory(int id, ProjectCategory category)
        {
            if (id != category.ProjectCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectCategoryExists(id))
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
        /// Summary: Creates a ProjectCategory 
        /// Produces: 
        ///     application/json
        /// Parameters: 
        ///    category
        ///     in: body
        ///     description: The project cateogry to create
        ///     required: True
        ///     type: ProjectCategory
        /// Responses: 
        ///     200 : Success
        [HttpPost]
        public async Task<ActionResult<ProjectCategory>> PostProjectCategory(ProjectCategory category)
        {
            _context.ProjectCategory.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectCategory", new { id = category.ProjectCategoryId }, category);
        }

       
        /// PUT
        /// Summary: Deletes a ProjectCategory matching an id
        /// Produces: 
        ///     application/json
        /// Parameters: 
        ///    id
        ///     in: path
        ///     description: The id of the ProjectCategory to delete
        ///     required: True
        ///     type: Integer
        /// Responses: 
        ///     204 : NoContent, If the category is removed
        ///     404 : NotFound, If there is not category to delete.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectCategory(int id)
        {
            var projectCategory = await _context.ProjectCategory.FindAsync(id);
            if (projectCategory == null)
            {
                return NotFound();
            }

            _context.ProjectCategory.Remove(projectCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Helper functions used to see if a category exists 
        //Parameters: The id of the ProjectCategory as an Integer
        private bool ProjectCategoryExists(int id)
        {
            return _context.ProjectCategory.Any(e => e.ProjectCategoryId == id);
        }
    }
}
