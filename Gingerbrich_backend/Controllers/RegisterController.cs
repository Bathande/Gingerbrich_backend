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
        [HttpPost("registration/{userType}")]
        public async Task<ActionResult<Customer>> Post(string userType,[FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var customerCheck = context.Customer.FirstOrDefaultAsync(x => x.username == customer.username);
                if (customer != null)
                {
                    customer.password = Encryption.CreatePasswordHash(customer.password);
                    context.Customer.Add(customer);
                    Permission userPerm = new Permission();
                    userPerm.type = userType;
                    context.Permission.Add(userPerm);
                    Customer_Permission cPerm = new Customer_Permission();
                    cPerm.PermissionId = userPerm.Id;
                    cPerm.CustomerId = customer.Id;
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
            customer.password = null;
            var tokenString =userAuth.GenerateJsonToken(customer);
            return Ok(new { user= customer, token = tokenString });
        }

    }
}
