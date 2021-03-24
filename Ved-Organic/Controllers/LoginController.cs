using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ved_Organic.Data;

namespace Ved_Organic.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string userId=" ",string pass=" ")
        {
            LoginResponse login = new LoginResponse();
            login.UserName = userId;
            login.Password = pass;

            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);
            if (user.UserName != "")
            { 
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new
                {
                    token = tokenString
                });
            }
            return response;
        }
        private LoginResponse AuthenticateUser(LoginResponse  log)
        {
            var user=new LoginResponse();
            if (log.UserName == "rpneha11@gmail.com" && log.Password=="123") {

                 user = new LoginResponse { UserId = 5, UserName = "rpneha11@gmail.com", Password = "123", PermissionString = "User" };
    }
            return user;
}
        
        private string GenerateJSONWebToken(LoginResponse userInfo)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Email,userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,userInfo.PermissionString)

            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                Claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials);
            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
        [Authorize()]
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            try
            {
                return Ok(value);
            }
            catch(Exception)
            {
                return NotFound();
            }
        }  
            
        }
    }

