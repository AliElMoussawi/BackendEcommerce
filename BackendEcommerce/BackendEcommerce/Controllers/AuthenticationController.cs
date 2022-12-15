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
        private readonly SessionRepository sessionRepository;

        public AuthenticationController(IConfiguration config, UserRepository userRepository, SessionRepository sessionRepository, AppDbContext context)
        {
            configuration = config;
            this.context = context;
            this.userRepository = userRepository;
            this.sessionRepository= sessionRepository;
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
                        string _token=new JwtSecurityTokenHandler().WriteToken(token);
                       Session session = new Session() { Token = _token+"", Creation=DateTime.UtcNow,User=user };
                       if(sessionRepository.Add(session)!=null){
                            return Ok(_token); }
                        return BadRequest("Could not add session");
                    }
                    else
                    {
                        return BadRequest("Invalid credentials");
                    }
                }
                else
                {
                    return BadRequest("user is not in db");
                }
            }
            return BadRequest("no body is given");
            }
        }
    }
