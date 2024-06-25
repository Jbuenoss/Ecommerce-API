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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var product = _productRepository.GetProduct(id);
            if(product == null)
                return NotFound();
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProduct([FromBody] ProductDto productdto, [FromQuery] int UserId)
        {

            if (!_productRepository.CheckUser(UserId))
                return BadRequest(ModelState);

            var product = _mapper.Map<Product>(productdto);

            if (!_productRepository.CreateProduct(product, UserId))
            {
                ModelState.AddModelError("erro", "Something's wrong in creation");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created!");
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] 
        public IActionResult UpdateProduct(ProductDto product)
        {
            var productMap = _mapper.Map<Product>(product);

            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            if (!_productRepository.UpdateProduct(productMap))
                return StatusCode(500, ModelState);

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteProduct([FromBody] int id)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            if (!_productRepository.CheckProduct(id))
                return NotFound();
            if (!_productRepository.DeleteProduct(id))
            {
                ModelState.AddModelError("erro", "Something's wrong in server");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
