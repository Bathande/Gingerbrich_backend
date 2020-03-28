using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gingerbrich_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Gingerbrich_backend.Helper;

namespace Gingerbrich_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ModelContext _context;

        public CustomerController(ModelContext context)
        {
            _context = context;
        }

        //GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetUser(int id)
        {
            var user = await _context.Customer.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, Customer user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
        [HttpPost("Login")]
        public async Task<ActionResult> Login(Customer userModel)
        {
            Customer user;
            try
            {
                user = await _context.Customer.FirstOrDefaultAsync(x => x.username == userModel.username && Encryption.VerifyPassword(userModel.password,x.password));

            }catch(DbUpdateConcurrencyException)
            {
                return BadRequest(new {status="failed", messege="Invalid Password or Username" });
            }
            string usertoken = new Authetication().GenerateJsonToken(user);
            user.password = null;
            return Ok(new { customer =user, token= usertoken });
        }
        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<Customer>> PostUser(Customer user)
        {
            _context.Customer.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        private bool UserExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
