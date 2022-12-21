using AutoMapper;
using BackendEcommerce.Dto;
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
        private readonly IMapper mapper;
        private readonly ProductRepository ProductRepository;
        public ProductController(ProductRepository ProductRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.ProductRepository = ProductRepository;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var Products = ProductRepository.GetProducts();
            if (!ModelState.IsValid)//model state check that the given model satisfies 
                return BadRequest(ModelState);
            return Ok(Products);
        }
       /* [HttpGet]
        public IActionResult GetProductrating([FromBody] int id)
        {
            var Products = ProductRepository.GetProductRating(id);
            if (!ModelState.IsValid)//model state check that the given model satisfies 
                return BadRequest(ModelState);
            return Ok(Products);
        }*/
        [HttpPost]
        public IActionResult addProduct([FromBody] ProductDto productDto)
        {
            var product = mapper.Map<Product>(productDto);
            var Product = ProductRepository.AddProduct(product);
            if (!ModelState.IsValid)//model state check that the given model satisfies 
                return BadRequest(ModelState);
            if (Product == null) { return BadRequest(Product); }
            return Ok(Product);
        }
        /*[HttpDelete]
        public IActionResult DeleteProduct([FromBody] int id)
        {
            var product = ProductRepository.ProductExist(id);
            if (product)
            {
                ProductRepository.DeleteProduct(id);
            }
            if (!ModelState.IsValid)//model state check that the given model satisfies 
                return BadRequest(ModelState);
            return Ok(product);
        }*/
    }
}
//after the first controller its very important to check the inection of the dependencies 
