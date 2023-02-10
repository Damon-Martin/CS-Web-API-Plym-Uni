/* 
 * University Of Plymouth: COMP 2001 Information Management & Retrieval
 * Student ID: 10729705
 * 
 * Description: Performs CRUD onto the User Table
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrailAPI.Models;

namespace TrailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Private Attribute: Holds DB Context with all tables
        private readonly CourseworkDbContext _context;

        // Constructor: Initialises DB Context into the private attribute _context
        public UserController(CourseworkDbContext context)
        {
            _context = context;
        }

        // GET: Api/User
        // Desc: Displays Entire Table by Listing asynchrounously the Users stored in the Context
        [HttpGet]
        public async Task<IActionResult> get()
        {
            // Model State is not valid therefore is broken
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _context.Users.ToListAsync());
        }

        // GET By ID: Api/User/{userID}
        // Desc: Displays the user entity found in the Users table if it has the geohash [Key] or returns an error
        [HttpGet("{userID}")]
        public async Task<IActionResult> getByKey([FromRoute] int userID)
        {
            // Model State is not valid therefore is broken
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Does Not Exist
            if (!userExists(userID))
            {
                return NotFound();
            }
            //Exists: Display the Description that matches geohash
            return Ok(await _context.Users.Where(c => c.UserId == userID).ToListAsync());
        }

        // PUT: Api/User
        // Desc: Updates an Entry, by getting a Custom Obj and propagates its values a User object and then asynchronously save to the DB Context via the private _context object
        [HttpPut]
        public async Task<IActionResult> updateByKey([FromBody] User data)
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
                if (!userExists(data.UserId))
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

        // POST: Api/User
        // Desc: Makes a new Entry, by getting a Custom Obj and propagates its values a User object and then adding it the context and then asynchronously save to the DB Context via the private _context object
        [HttpPost]
        public async Task<ActionResult<User>> create([FromBody] CreateUser user)
        {
            // Model State is not valid therefore is broken
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User newUser = new User();

            //Propagating/Copying Data from the JSON to the User Object
            newUser.Email = user.Email;
            newUser.FirstName = user.FirstName;
            newUser.LastName = user.LastName;

            //Adding User to Context
            _context.Users.Add(newUser);

            //Async await for the changes to be made then it will save
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE Api/User/{ID}
        // Desc: Deletes an Entry by ID, looks for item in table found in db context and deletes then asynchonously updates and saves the DB Context and returns status OK
        [HttpDelete("{userID}")]
        public async Task<IActionResult> delete([FromRoute] int userID)
        {
            // Model State is not valid therefore is broken
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Searching and storing queried user into object
            var selectedUser = await _context.Users.FindAsync(userID);

            //Does not exist: Return not found
            if (selectedUser == null)
            {
                return NotFound();
            }

            //Delete User
            _context.Users.Remove(selectedUser);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Bool Func: Checks if ID matches any Users in the current context
        private bool userExists([FromRoute] int id)
        {
            return (_context.Users.Any(e => e.UserId == id));
        }
    }
}
