/* 
 * University Of Plymouth: COMP 2001 Information Management & Retrieval
 * Student ID: 10729705
 * 
 * Description: Performs CRUD onto the Author Table
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrailAPI.Models;

namespace TrailAPI.Controllers
{

    [Route("api/[controller]/")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        // Private Attribute: Holds DB Context with all tables
        private readonly CourseworkDbContext _context;

        // Constructor: Initialises DB Context into the private attribute _context
        public AuthorsController(CourseworkDbContext context)
        {
            _context = context;
        }

        // GET: Authors
        // Description: Displays Entire Table
        // Explained: Gets the Table from Context and turns it into a List then returns the list
        [HttpGet]
        public async Task<IActionResult> get()
        {
            // Model State is not valid therefore is broken
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Displays all authors stored in the DbContext's Authors
            return Ok(await _context.Authors.ToListAsync());
        }


        // GET: Api/Authors/{trailID}
        // Desc: Displays Entire Table by Listing asynchrounously the Author stored in the Context
        [HttpGet("{trailID}")]
        public async Task<IActionResult> getByKey([FromRoute] int trailID)
        {
            // Model State is not valid therefore is broken
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Doesn't Exist: Informs Not found
            if (!authorExists(trailID))
            {
                return NotFound();
            }
            //Exists: Display the Desired Author
            return Ok(await _context.Authors.FindAsync(trailID));
        }


        // PUT: Api/Author/
        // Desc: Displays the author entity found in the Author table if it has the geohash [Key] or returns an error
        [HttpPut]
        public async Task<IActionResult> updateByKey([FromBody] Author dataAuthor)
        {
            // Model State is not valid therefore is broken
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Attempts to Update
            _context.Entry(dataAuthor).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            //Not Found: Valid input
            catch (DbUpdateConcurrencyException)
            {
                if (!authorExists(dataAuthor.TrailID))
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

        // POST: Api/Author
        // Desc: Makes a new Entry, by getting a Custom Obj and propagates its values a Author object and then adding it the context and then asynchronously save to the DB Context via the private _context object
        [HttpPost]
        public async Task<ActionResult<Author>> create([FromBody] CreateAuthor dataAuthor)
        {
            // Model State is not valid therefore is broken
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Author newAuthor = new Author();
            newAuthor.author = dataAuthor.author;


            _context.Authors.Add(newAuthor);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE Api/Author/{ID}
        // Desc: Deletes an Entry by ID, looks for item in table found in db context and deletes then asynchonously updates and saves the DB Context and returns status OK
        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> delete([FromRoute] int id)
        {
            // Model State is not valid therefore is broken
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var selectedAuthor = await _context.Authors.FindAsync(id);
            if (selectedAuthor == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(selectedAuthor);
            await _context.SaveChangesAsync();

            return selectedAuthor;
        }


        private bool authorExists(int id)
        {
            return (_context.Authors.Any(e => e.TrailID == id));
        }

    }

}
