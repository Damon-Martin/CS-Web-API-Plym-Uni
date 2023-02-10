/* 
 * University Of Plymouth: COMP 2001 Information Management & Retrieval
 * Student ID: 10729705
 * 
 * Description: Performs CRUD onto the TrailUsers Table
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrailAPI.Models;

namespace TrailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrailUsersController : ControllerBase
    {
        // Private Attribute: Holds DB Context with all tables
        private readonly CourseworkDbContext _context;

        // Constructor: Initialises DB Context into the private attribute _context
        public TrailUsersController(CourseworkDbContext context)
        {
            _context = context;
        }

        // Get: Api/TrailUsers
        // Desc: Gets all items from TrailUsers Table found in the private _context attribute holding DB Context
        [HttpGet]
        public async Task<IActionResult> get()
        {
            // Model State is not valid therefore is broken
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _context.TrailUsers.ToListAsync());
        }

        // Get By Compound Key: Api/TrailUsers/{trailID}/{userID}
        // Desc: Get entity by Compound Key from the DB Context in the private attribute _context
        [HttpGet("{trailID}/{userID}")]
        public async Task<IActionResult> getByKey([FromRoute] int trailID, [FromRoute] int userID)
        {
            // Model State is not valid therefore is broken
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Store if Get Req into object
            var QueriedTrailUsers = await _context.TrailUsers.FindAsync(trailID, userID);

            // Not in TrailUsers
            if (QueriedTrailUsers == null)
            {
                return NotFound();
            }
            // Exists: True and return the item
            else
            {
                return Ok(QueriedTrailUsers);
            }
        }

        // Put: Api/TrailUsers
        // Desc: From a Custom Model Object, I propagate it's values to an instatiated TrailUsers object. Save to context or return an error.
        [HttpPut]
        public async Task<IActionResult> updateByKey([FromBody] TrailUser data)
        {
            try
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
                    //Checking if Compound Key is in the Table
                    if (!trailUsersExists(data.UserId, data.TrailId))
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
            catch
            {
                return BadRequest();
            }
        }

        // Post: Api/TrailUsers
        // Desc: From a Custom Model Object, I propagate it's values to an instatiated TrailUsers object then add to the table via the private _context attribute and save it
        [HttpPost]
        public async Task<IActionResult> create([FromBody] TrailUser data)
        {
            try
            {
                // Model State is not valid therefore is broken
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                //Save it to the DB
                _context.TrailUsers.Add(data);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                //Error handling: Just in case (Should be fine)
                return BadRequest();
            }
        }

        // DELETE: Broken
        [HttpDelete("{trailID}/{userID}")]
        public async Task<IActionResult> delete([FromRoute] int trailID, [FromRoute] int userID)
        {
            // Model State is not valid therefore is broken
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Finding if Desc exists
            var QueriedTrailUsers = await _context.TrailUsers.FindAsync(trailID, userID);

            //Does Not Exists: Return not found
            if (QueriedTrailUsers == null)
            {
                return NotFound();
            }

            //Exists: Therefore Delete
            _context.TrailUsers.Remove(QueriedTrailUsers);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Bool Func: Checks if TrailUser Entity Exists
        private bool trailUsersExists(int userID, int trailID)
        {
            // Returns T/F if both attributes are found in the same element (Compound Key)
            return _context.TrailUsers.Any(e => e.UserId == userID && e.TrailId == trailID);
        }


    }
}
