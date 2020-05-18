using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gingerbrich_backend.Helper;
using Gingerbrich_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Type = Gingerbrich_backend.Models.Type;

namespace Gingerbrich_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ModelContext context;
        public RegisterController(ModelContext context)
        {
            this.context = context;
        }
        // POST: api/Register
        [HttpPost("registration/{type}")]
        public async Task<ActionResult<Customer>> Post(Type type,[FromBody] Customer customer)
        {
            if (!ModelState.IsValid)  return BadRequest(ModelState);
            
            try
            {
                var customerCheck = context.Customer.FirstOrDefaultAsync(x => x.Username == customer.Username);
                if (customer != null)
                {
                    customer.Password = Encryption.CreatePasswordHash(customer.Password);
                    context.Customer.Add(customer);
                    Permission userPerm = new Permission();
                    userPerm.type = type;
                    context.Permission.Add(userPerm);
                    Customer_Permission cPerm = new Customer_Permission()
                    {
                        customer = customer,
                        permission = userPerm
                    };
                    context.Customer_Permission.Add(cPerm);
                    await context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = "user already Exist" });
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            Authetication userAuth = new Authetication();
            customer.Password = null;
            var tokenString =userAuth.GenerateJsonToken(customer);
            return Ok(new { user= customer, token = tokenString });
        }
    
    }
}
