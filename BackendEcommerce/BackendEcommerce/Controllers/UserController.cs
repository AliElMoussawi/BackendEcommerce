using AutoMapper;
using BackendEcommerce.Dto;
using BackendEcommerce.Models;
using BackendEcommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackendEcommerce.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserRepository userRepository;
        private readonly IMapper mapper;
        public UserController(UserRepository userRepository,IMapper mapper) {

            this.mapper=mapper;
            this.userRepository = userRepository;
        }
        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<User>))]
        [ProducesResponseType(400)]
        public IActionResult getUsers()
        {
           var users =mapper.Map<List<UserDto>>(userRepository.GetUsers());
          if(!ModelState.IsValid)//model state check that the gien model satisfies 
            return BadRequest(ModelState);
          return Ok(users);
        }
    }
}
//after the first controller its very important to check the inection of the dependencies 
