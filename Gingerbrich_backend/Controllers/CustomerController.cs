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
using Gingerbrich_backend.HelperModels;

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
        public async Task<ActionResult> Login([FromBody] UserLogin userModel)
        {
            Customer customer;
            try
            {
                customer = await _context.Customer.FirstOrDefaultAsync(x => x.Username == userModel.username && Encryption.VerifyPassword(userModel.password,x.Password));
                if(customer == null)
                {
                    return NotFound(new {message = "Invalid Password or Username" });
                }

            }catch(DbUpdateConcurrencyException)
            {
                return BadRequest(new { message="Failed" });
            }
            string usertoken = new Authetication().GenerateJsonToken(customer);
            customer.Password = null;
            return Ok(new { user = customer, token= usertoken });
        }

        private bool UserExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
