using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Gingerbrich_backend.Models;

namespace Gingerbrich_backend.Helper
{
    public class Authetication
    {      
        public string GenerateJsonToken(Customer user)
        {
            try
            {
                var s = Environment.GetEnvironmentVariable("Key");
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("Key")));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            };
                var token = new JwtSecurityToken(Environment.GetEnvironmentVariable("Issuer"),
                Environment.GetEnvironmentVariable("Issuer"), claims,
                expires: DateTime.Now.AddDays(360),
                signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch(Exception e)
            {
                return e.ToString();
            }
          
        }
    }
}
