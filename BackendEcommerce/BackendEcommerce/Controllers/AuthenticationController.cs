using AutoMapper;
using BackendEcommerce.Dto;
using BackendEcommerce.Models;
using BackendEcommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BackendEcommerce.Dto.Helper;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace BackendEcommerce.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public IConfiguration configuration;
        private readonly AppDbContext context;
        private readonly UserRepository userRepository;
        public AuthenticationController(IConfiguration config, UserRepository userRepository, AppDbContext context)
        {
            configuration = config;
            this.context = context;
            this.userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Login([FromBody] AuthenticationRequest _userData)
        {

            if (_userData != null && _userData.UserName != null && _userData.Password != null)
            {
                var user = context.Users.Where(u => u.UserName == _userData.UserName).FirstOrDefault();
                if (user != null)
                {


                    var str = context.Passwords.Where(u => u.User.Id == user.Id && u.Valid == true).FirstOrDefault().HashedPassword;
                   bool pass = _userData.Password== str;
                    if (pass)
                    {      //create claims details based on the user information
                        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("DisplayName", user.Name),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.Email)
                    };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            configuration["Jwt:Issuer"],
                            configuration["Jwt:Audience"],
                            claims,
                            signingCredentials: signIn);

                        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                    }
                    else
                    {
                        return BadRequest("Invalid credentials");
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            return BadRequest();
            }
        }
    }
