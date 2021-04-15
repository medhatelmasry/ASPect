using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Data;
using ASPectLibrary;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    /// A WebAPI Controller for dealing wtih ProgressUpdates
    [ApiController]
    [Route("api/ProgressUpdate")]
    public class ProgressUpdateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProgressUpdateController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// GET
        /// Fetches all ProgressUpdate's from the db
        /// 
        /// Returns: A 200, OK
        [HttpGet]
        public async Task<IActionResult> GetAllProgressUpdates()
        {
            return Ok(await _context.ProgressUpdates.ToListAsync());
        }

        /// POST
        /// Post a ProgressUpdate's from the db
        /// 
        /// Returns: A 202, Accepted,
        ///            404, If ProgressUpdate not found
        [HttpPost]
        public async Task<IActionResult> PostProgressUpdate(ProgressUpdate progressUpdate)
        {
            try
            {
                _context.ProgressUpdates.Add(progressUpdate);
                await _context.SaveChangesAsync();
                return Accepted();
            }
            catch
            {
                return NotFound();
            }
        }


        /// DELETE
        /// Deletes a ProgressUpdate from the db
        /// 
        /// Returns: A 202, OK
        ///            404, If ProgressUpdate not found
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgressUpdate(int id)
        {
            var progressUpdate = await _context.ProgressUpdates.FindAsync(id);

            if (progressUpdate == null) { return NotFound(); }

            _context.ProgressUpdates.Remove(progressUpdate);
            await _context.SaveChangesAsync();

            return Accepted();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SetCompleted(int id)
        {
            var progressUpdate = await _context.ProgressUpdates.FindAsync(id);

            if (progressUpdate == null) { return NotFound(); }
            progressUpdate.Complete = true;
            _context.ProgressUpdates.Update(progressUpdate);
            await _context.SaveChangesAsync();

            return Ok();
        }
        /// PUT
        /// Updates a ProgressUpdate in the DB
        /// 
        /// Returns: A 202, OK
        ///            404, if ProgressUpdate not found
        [HttpPut]
        public async Task<IActionResult> UpdateProgressUpdate(ProgressUpdate progressUpdate)
        {
            var newPU = await _context.ProgressUpdates.FindAsync(progressUpdate.Id);

            if (newPU == null) { return NotFound(); }

            _context.ProgressUpdates.Update(progressUpdate);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}




