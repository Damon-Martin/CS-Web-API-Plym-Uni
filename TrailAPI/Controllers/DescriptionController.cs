/* 
 * University Of Plymouth: COMP 2001 Information Management & Retrieval
 * Student ID: 10729705
 * 
 * Description: Performs CRUD onto the Description Table
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrailAPI.Models;

namespace TrailAPI.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class DescriptionController : ControllerBase
    {
        // Private Attribute: Holds DB Context with all tables
        private readonly CourseworkDbContext _context;

        // Constructor: Initialises DB Context into the private attribute _context
        public DescriptionController(CourseworkDbContext context)
        {
            _context = context;
        }

        // Get: Api/Description
        // Desc: Displays Entire Table by Listing asynchrounously the Descriptions stored in the Context
        [HttpGet]
        public async Task<IActionResult> get()
        {
            return Ok(await _context.Descriptions.ToListAsync());
        }

        // GET BY ID: Api/Description/{geohash}
        // Primary Key: geohash
        // Desc: Displays the location entity found in the Description table if it has the geohash [Key] or returns an error

        [HttpGet("{geohash}")]
        public async Task<IActionResult> getByKey([FromRoute] string geohash)
        {
            // Model State is not valid therefore is broken
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Does Not Exist
            if (!locationExists(geohash))
            {
                return NotFound();
            }
            //Exists: Display the Description that matches geohash
            return Ok(await _context.Descriptions.Where(c => c.Geohash == geohash).ToListAsync());
        }

        // PUT: Api/Description/
        // Desc: If geohash is in DB. This puts the data into Description by propagating data object data into a Description object and saves it into context
        [HttpPut]
        public async Task<IActionResult> updateByKey([FromBody] Description data)
        {
            // Model State is not valid therefore is broken
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Attempts to Update
            _context.Entry(data).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            //Not Found: Valid input
            catch (DbUpdateConcurrencyException)
            {
                if (!locationExists(data.Geohash))
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

        // POST: Api/Description
        // Desc: This gets a Description Object from JSON via a HTTP POST Req and saves it into the DB or recieves an error
        [HttpPost]
        public async Task<ActionResult<Description>> create([FromBody] Description newDesc)
        {
            // Model State is not valid therefore is broken
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Descriptions.Add(newDesc);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: Api/Description
        // Desc: This Searches if the geohash[Key] Exists in the DB. If it does then delete from DB Context.
        [HttpDelete("{geohash}")]
        public async Task<IActionResult> delete([FromRoute] string geohash)
        {
            // Model State is not valid therefore is broken
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var selectedDesc = await _context.Descriptions.FindAsync(geohash);
            if (selectedDesc == null)
            {
                return NotFound();
            }

            _context.Descriptions.Remove(selectedDesc);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Bool Func
        // Desc: Checks if location exists in Description table found in DB Context held in the private attribute of this class
        private bool locationExists(string geohash)
        {

            //Returns true or false if any Description has the Geohash attribute equal to the geohash string
            return (_context.Descriptions.Any(e => e.Geohash == geohash));
        }

    }
}
