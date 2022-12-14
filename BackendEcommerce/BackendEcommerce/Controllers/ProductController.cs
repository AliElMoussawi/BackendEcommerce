using BackendEcommerce.Models;
using BackendEcommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendEcommerce.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductRepository ProductRepository;
        public ProductController(ProductRepository ProductRepository) {

            this.ProductRepository = ProductRepository;
        }
        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Product>))]
        public IActionResult getProducts()
        {
           var Products=ProductRepository.GetProducts();
          if(!ModelState.IsValid)//model state check that the given model satisfies 
            return BadRequest(ModelState);
          return Ok(Products);
        }
    }
}
//after the first controller its very important to check the inection of the dependencies 
