using BackendEcommerce.Models;
using BackendEcommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendEcommerce.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserRepository userRepository;
        public UserController(UserRepository userRepository) {

            this.userRepository = userRepository;
        }
        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<User>))]
        public IActionResult getUsers()
        {
           var users=userRepository.GetUsers();
          if(!ModelState.IsValid)//model state check that the gien model satisfies 
            return BadRequest(ModelState);
          return Ok(users);
        }
    }
}
//after the first controller its very important to check the inection of the dependencies 
