using AutoMapper;
using EcommerceAPI.Dto;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller //set of actions
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type= typeof(ICollection<Product>))]
        public IActionResult GetProducts()
        {
            var products = _mapper.Map<ICollection<ProductDto>>(_productRepository.GetProducts());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type= typeof(Product))]
        public IActionResult GetProduct(int id)
        {
            var pokemon = _mapper.Map<ProductDto>(_productRepository.GetProduct(id));
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemon);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProduct([FromBody] Product product, [FromQuery] int UserId)
        {

            if (!_productRepository.CheckUser(UserId))
                return BadRequest(ModelState);

            if (!_productRepository.CreateProduct(product, UserId))
            {
                ModelState.AddModelError("erro", "Somethings wrong in creation");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created!");
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] 
        public IActionResult UpdateProduct(Product product)
        {
            //var productMap = _mapper.Map<Product>(product);

            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_productRepository.UpdateProduct(product))
                return StatusCode(500, ModelState);

            return NoContent();
        }

    }
}
